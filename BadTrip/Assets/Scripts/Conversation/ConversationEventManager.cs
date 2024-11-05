using UnityEngine;
using Fungus;
using Cinemachine;
using System.Collections;

public class ConversationEventManager : MonoBehaviour
{
    // ��ȭâ, �ƾ� �̵�, ����Ʈ ���� ����
    [SerializeField] private Character[] characters;
    [SerializeField] private SayDialogSO sayDialogSO;
    [SerializeField] private Transform[] viewTrs;
    [SerializeField] private CinemachineVirtualCamera conVCam;
    [SerializeField] private InteractionObjectsSO interactionObjectsSO;
    private GameObject playerVCam;

    // ���� ���� ����
    [SerializeField] private AudioCue audioCue;

    private void Start()
    {
        // �� �� ĳ���� �� ��ȭâ �ʱ�ȭ
        foreach (Character cha in characters)
        {
            int dialogType = cha.GetComponent<CharacterInfo>().dialogType;

            cha.SetSayDialog = sayDialogSO.dialogs[dialogType];
        }

    }

    #region Cutscene
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
    #endregion

    #region Flowchart Call
    public void SendFlowchartMessage(string message) // �÷ο���Ʈ ��� �޽����� �θ���
    {
        Fungus.Flowchart.BroadcastFungusMessage(message);
    }
    #endregion

    #region Player Animation Setting
    public void SetPlayerAnimLayer(int num) // Player �ִϸ����� layer ����
    {
        sayDialogSO.SetPlayerAnimLayer(num);
    }

    public void SetPlayerAnim(string boolName, bool b) // Player �ִϸ��̼� ����
    {
        sayDialogSO.SetPlayerAnim(boolName, b);
    }
    #endregion

    #region Player Setting
    public void SetCanMove(bool b) // �÷��̾� Move Control
    {
        StopPlayer();
        sayDialogSO.SetCanMove(b);
    }

    public void SetFootstepVolume(float v) // �÷��̾� �߼Ҹ� ���� ����
    {
        sayDialogSO.SetFootstepVolume(v);
    }

    public void SetPlayerPos(Vector2 pos, bool isFlip = false) // �÷��̾� ��ġ ����
    {
        sayDialogSO.movePlayerPos(pos, isFlip); 
    }

    public void SetPlayerFlip(bool b)
    {
        sayDialogSO.SetPlayerFlip(b);
    }

    public void StopPlayer()
    {
        sayDialogSO.StopPlayer();
    }

    public void PlayerSetActive(bool b)
    {
        sayDialogSO.PlayerSetActive(b);
    }
    #endregion

    #region Scene Sound Setting
    public void PlayAudio(int num) // SFX ���
    {
        audioCue.PlayAudio(num);
    }

    public void StopAudio(int num) // SFX ����
    {
        audioCue.StopAudio(num);
    }
    #endregion

    #region QuestComplete
    public void CompleteQuest(int i = 1) // ����Ʈ ����(��ȭ ���� ���)
    {
        interactionObjectsSO.CompleteConQuest(i);
    }

    public void UpdateQuest()
    {
        interactionObjectsSO.RaiseEvent();
    }
    #endregion

    public void SetSortingLayer(SpriteRenderer sp, string layer, int order) {
        sp.sortingLayerName = layer;
        sp.sortingOrder = order;
    }

    public void SetPlayerSortingLayer(string layer, int order)
    {
        sayDialogSO.SetPlayerSortingLayer(layer, order);
    }

    public void SetActiveMenuBg(bool b)
    {
        sayDialogSO.menuBackground.SetActive(b);
    }

    public void SetIsDialog(bool b)
    {
        sayDialogSO.SetIsDialog(b);
    }
}
