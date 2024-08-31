using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class QuestBase
{
    public bool isClear = false;
    public int interactionId; // ��ȣ�ۿ��ؾ� �ϴ� ������Ʈ id

    public abstract void QuestFunction();
}

[Serializable]
public class Quest_Conversation : QuestBase // ��ȭâ ������ ����Ʈ
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
public class Quest_Move : QuestBase // �÷��̾� �̵��ϴ� ����Ʈ
{
    public string message; // �ݰŽ� ȣ�� �޽���

    public override void QuestFunction() {
        Fungus.Flowchart.BroadcastFungusMessage(message);
        isClear = true;
        // �Ŀ� �߰�
    }
}

