using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class QuestBase
{
    public int questType; // 0 : �÷��̾� ��ȣ�ۿ��ϴ� ����Ʈ 1 : �� �̵��ϴ� ����Ʈ 
    public bool isClear = false;
    public int interactionId; // ��ȣ�ۿ��ؾ� �ϴ� ������Ʈ id
    public Player player;

    public abstract void QuestFunction();
}

[Serializable]
public class Quest_Interaction : QuestBase // �÷��̾� ��ȣ�ۿ��ϴ� ����Ʈ
{
    public string message; // �ݰŽ� ȣ�� �޽���
    
    public override void QuestFunction()
    {
        Fungus.Flowchart.BroadcastFungusMessage(message);
        isClear = true;
        // �Ŀ� �߰�
    }
}

[Serializable]
public class Quest_Move : QuestBase // �� �̵��ϴ� ����Ʈ
{
    public string message; // �ݰŽ� ȣ�� �޽���

    public override void QuestFunction() {
        Fungus.Flowchart.BroadcastFungusMessage(message);
    }
}

