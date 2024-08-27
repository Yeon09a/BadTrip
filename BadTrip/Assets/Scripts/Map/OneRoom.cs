using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRoom : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private ConversationEventManager conEventMng;

    // ����Ʈ ���� ���� // �Ŀ� ����, ���� �ʿ�
    [SerializeField] private GameObject mark;

    void Start()
    {
        if (playerData.eventNum == 0)
        {
            conEventMng.SetPlayerAnimLayer(1);
            // �÷��̾� ������, �÷��̾� �ִϸ��̼� ���߱�
            conEventMng.SetPlayerAnim("CanPMove", false);
        }
        else if (playerData.eventNum == 1)
        {
            mark.SetActive(false);
            Fungus.Flowchart.BroadcastFungusMessage("LookMirror");

        }
    }
}
