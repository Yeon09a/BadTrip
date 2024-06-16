using UnityEngine;
using Fungus;
using Cinemachine;
using System.Collections;

public class ConversationEventManager : MonoBehaviour
{
    // ��ȭâ, �� �̵� ���� ����
    [SerializeField] private Character[] characters;
    [SerializeField] private SayDialogSO sayDialogSO;
    [SerializeField] private Transform[] viewTrs;
    [SerializeField] private CinemachineVirtualCamera conVCam;
    private GameObject playerVCam;

    // �÷ο� ��Ʈ ���� ����
    [SerializeField] private MessageReceived receiver;

    // ���� ���� ����
    [SerializeField] private AudioCue audioCue;

    [SerializeField] private PlayerDataSO playerData;

    private void Start()
    {
        foreach (Character cha in characters)
        {
            int dialogType = cha.GetComponent<CharacterInfo>().dialogType;

            cha.SetSayDialog = sayDialogSO.dialogs[dialogType];
        }

        if (playerData.eventNum == 1)
        {
            Debug.Log(111);

            receiver.gameObject.SetActive(true);
        } else if(playerData.eventNum == 2){
            
            receiver.gameObject.SetActive(true);

        }

    }

    public void ShowCutscene(int viewNum) // �ƾ� �̵�
    {
        conVCam.Follow = viewTrs[viewNum];
        if (playerVCam == null)
        {
            playerVCam = GameObject.FindGameObjectWithTag("VCam");
            playerVCam.SetActive(false);
            conVCam.gameObject.SetActive(true);
        }
    }

    public void BackFromCutscene() // �ƾ����� ���ƿ�
    {
        playerVCam.SetActive(true);
        conVCam.gameObject.SetActive(false);
        playerVCam = null;
    }


    public void SendFlowchartMessage(string message) // �÷ο���Ʈ ��� �޽����� �θ���
    {
        receiver?.OnSendFungusMessage(message);
    }

    public void SetPlayerAnimLayer()
    {
        sayDialogSO.SetPlayerAnimLayer();
    }

    public void SetPlayerAnim(string boolName, bool b)
    {
        sayDialogSO.SetPlayerAnim(boolName, b);
    }

    public  void SetCanMove(bool b)
    {
        sayDialogSO.SetCanMove(b);
    }

    public void PlayAudio(int num)
    {
        audioCue.PlayAudio(num);
    }

    public void StopAudio(int num)
    {
        audioCue.StopAudio(num);
    }
}
