using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SceneInfoSO")]
public class SceneInfoSO : ScriptableObject
{
    public bool isPlayer = true;
    public bool isDialog = true;
    public int playerRen = 1; // �÷��̾� ����
    //public bool isRight = false;

    //public int eventNum;
    public string sceneName;
}
