using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private SceneMove sceneMove;

    [SerializeField]
    private List<QuestInfoSO> questSet; // ����Ʈ ����
    private Dictionary<int, QuestInfoSO> questDic = new Dictionary<int, QuestInfoSO>();

    public int curQuestId = 0;
    public QuestInfoSO info; // ���� ����Ʈ ����
    [SerializeField]
    private InteractionObjectsSO interactionObjects;

    private void Start()
    {
        LoadAllQuestData();
    }

    private void OnEnable()
    {
        interactionObjects.UpdateQuestScene += UpdateQuestState;
        interactionObjects.UpdateQuestScene += UpdateQuestScene;
    }

    private void OnDisable()
    {
        interactionObjects.UpdateQuestScene -= UpdateQuestState;
        interactionObjects.UpdateQuestScene -= UpdateQuestScene;
    }

    private void LoadAllQuestData() // ���� ���� �� ó�� ��� ����Ʈ ������ �纻�� ����.
    {
        foreach (QuestInfoSO questInfo in questSet)
        {
            QuestInfoSO questinfoCopy = Instantiate(questInfo);

            List<QuestBase> allQuests = new List<QuestBase>();
            foreach (QuestBase questBase in questinfoCopy.InterQuest)
            {
                allQuests.Add(questBase);
            }
            foreach (QuestBase questBase in questinfoCopy.moveQuests)
            {
                allQuests.Add(questBase);
            }

            questinfoCopy.allQuests = allQuests.ToArray();

            questDic.Add(questInfo.questId, questinfoCopy);
        }
    }

    public void LoadQuest(int questId)
    {
        info = questDic[questId];
        
        UpdateQuestScene();
    }

    public void CompleteQuest()
    {
        curQuestId++;
        if (curQuestId < questSet.Count)
        {
            LoadQuest(curQuestId);
        }
    }

    public void UpdateQuestState(int? objId) // ����Ʈ ���� ������Ʈ. �÷��̾ ��ȣ�ۿ��� �� �� ȣ���.
    {
        // ��ȣ�ۿ��� ������Ʈ ���̵� �˻��ؼ� üũ
        for (int i = 0; i < info.allQuests.Length; i++)
        {
            if (objId == info.allQuests[i].interactionId && !info.allQuests[i].isClear)
            {
                // ��ȣ�ۿ� �ൿ.
                info.allQuests[i].QuestFunction();
                info.clearCount++;
            }
        }

        // ��� �̴�����Ʈ�� Ŭ����Ǹ�
        if ((info.isLast && info.allQuests[--info.questCount].isClear) || info.clearCount == info.questCount)
        {
            CompleteQuest();
        }
    }

    public void UpdateQuestState() // ����Ʈ ���� ������Ʈ. �÷��̾ ���� �̵��� �� ȣ���.
    {
        // �̵��� ���� ����Ʈ ���� ��
        if (info == null)
        {
            return;
        }

        if (info.sceneName == sceneMove.curSceneName && info.allQuests[0].questType == 1 && !info.allQuests[0].isClear)
        {
            info.allQuests[0].QuestFunction();
            info.clearCount++;
        }

            // ��� �̴�����Ʈ�� Ŭ����Ǹ�
        if ((info.isLast && info.allQuests[info.questCount -1].isClear) || info.clearCount == info.questCount)
        {
            CompleteQuest();
        }
    }

    public void UpdateQuestScene() // �� ���� �� ó�� �� ����Ʈ ����ǥ ������Ʈ
    {
        if (info == null)
        {
            return;
        }
        
        if (info.sceneName == sceneMove.curSceneName)
        {
            for (int i = 0; i < info.allQuests.Length; i++)
            {
                if (info.allQuests[i].questType == 0 && !info.allQuests[i].isClear)
                {
                    interactionObjects.interactionObjs[info.allQuests[i].interactionId]?.GetComponent<MapInteractionObject>().SetBang(true);
                }
            }
        }
    }
}