using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConversationManager : MonoBehaviour // �� ���� Initialization �� ����
{
    [SerializeField] private SayDialog[] sayDialogs;

    [SerializeField] private SayDialogSO SayDialogSO;

    [SerializeField] private Player player;

    private void Awake()
    {
        SayDialogSO.dialogs = sayDialogs;
        SayDialogSO.SetPlayerAnimLayer += player.SetAnimLayer;
        SayDialogSO.SetPlayerAnim += player.SetPlayerAnim;
        SayDialogSO.SetCanMove += player.SetCanMove;
        SayDialogSO.SetFootstepVolume += player.SetFootstepVolume;
        SayDialogSO.movePlayerPos += player.SetPlayerPos;
        SayDialogSO.StopPlayer += player.StopPlayer;
        SayDialogSO.PlayerSetActiveOFF += player.PlayerSetActiveOFF;
    }

    private void OnDisable()
    {
        SayDialogSO.SetPlayerAnimLayer -= player.SetAnimLayer;
        SayDialogSO.SetPlayerAnim -= player.SetPlayerAnim;
        SayDialogSO.SetCanMove -= player.SetCanMove;
        SayDialogSO.SetFootstepVolume -= player.SetFootstepVolume;
        SayDialogSO.movePlayerPos -= player.SetPlayerPos;
        SayDialogSO.StopPlayer -= player.StopPlayer;
        SayDialogSO.PlayerSetActiveOFF -= player.PlayerSetActiveOFF;
    }
}
