using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AudioSourcePoolSO")]
public class AudioSourcePoolSO : ScriptableObject
{
    public int asCount; // �ʿ��� ����� ����� Ŭ�� ������Ʈ ����

    public void DisableAS(AudioSource[] objects) // ������Ʈ ��Ȱ��ȭ
    {
        foreach (AudioSource ob in objects)
        {
            ob.gameObject.SetActive(false);
        }
    }

    public AudioSource EnableAS(AudioSource[] objects, int audioNum) // ������Ʈ Ȱ��ȭ
    {
        objects[audioNum].gameObject.SetActive(true);
        return objects[audioNum];
    }
}
