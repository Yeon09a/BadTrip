using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� Ŭ����(Json���� ��ȯ�� Ŭ����)
[Serializable]
public class JsonData
{
    public string playerName;
    public int questId;
    public bool[] questPro;
    public string sceneName;
    public Vector2 playerPos;
    public int animLayer;
    public bool isflip;
}
