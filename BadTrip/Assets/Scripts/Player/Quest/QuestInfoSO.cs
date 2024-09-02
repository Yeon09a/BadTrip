using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/QuestInfoSO")]
public class QuestInfoSO : ScriptableObject
{
    [TextArea(2, 8)]
    public string explain;
    
    public int questId;
    public string sceneName; // ����Ʈ�� �����ϴ� �� �̸�
    //public int[] objsId; // ��ȣ�ۿ� �ؾ��ϴ� ������Ʈ ���̵�
    public int questCount; // �� ����Ʈ �� ���� ���� ����Ʈ�� ���� ���, ����Ʈ ����
    public int clearCount; // Ŭ������ ����Ʈ ����
    public bool isLast; // ������ �ִ� ����Ʈ����. ������ �ִ� ����Ʈ�� ��� ������ ����Ʈ�� Ŭ���� �ϸ� ��.

    public Quest_Interaction[] InterQuest;
    public Quest_Move[] moveQuests;

    public QuestBase[] allQuests;
}
