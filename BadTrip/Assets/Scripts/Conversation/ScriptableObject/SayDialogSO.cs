using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CreateAssetMenu(menuName = "Conversation/SayDialogSO")]
public class SayDialogSO : ScriptableObject // Initialization ���� �� �� ������ ���� �͵�
{
    public SayDialog[] dialogs;
    public Action<int> SetPlayerAnimLayer;
    public Action<string, bool> SetPlayerAnim;
    public Action<bool> SetCanMove, PlayerSetActive, SetIsDialog, SetPlayerFlip, SetCanChangeBGM;
    public Action<float> SetFootstepVolume;
    public Action<Vector2, bool> movePlayerPos;
    public Action StopPlayer, BackToMain, BackToMainWhite;
    public Action<string, int> SetPlayerSortingLayer;
    public GameObject menuBackground;
}
