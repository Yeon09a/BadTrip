using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/QuestInfoSO")]
public class QuestInfoSO : ScriptableObject
{
    [TextArea]
    public string explain;
    
    public int questId;
    public string sceneName; // ����Ʈ�� �����ϴ� �� �̸�
    //public int[] objsId; // ��ȣ�ۿ� �ؾ��ϴ� ������Ʈ ���̵�
    public int questCount; // �� ����Ʈ �� ���� ���� ����Ʈ�� ���� ���, ����Ʈ ����
    public int clearCount; // Ŭ������ ����Ʈ ����
    public bool isLast; // ������ �ִ� ����Ʈ����. ������ �ִ� ����Ʈ�� ��� ������ ����Ʈ�� Ŭ���� �ϸ� ��.

    public Quest_Move[] moveQuests;
    public Quest_Conversation[] conQuests;

    public QuestBase[] allQuests;
}
