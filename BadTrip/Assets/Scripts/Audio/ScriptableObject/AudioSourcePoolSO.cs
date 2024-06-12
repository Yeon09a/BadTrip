using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AudioSourcePoolSO")]
public class AudioSourcePoolSO : ScriptableObject
{
    public void DisableAS(AudioSource[] objects) // ������Ʈ ��Ȱ��ȭ
    {
        foreach (AudioSource ob in objects)
        {
            ob.Stop();
        }
    }
}
