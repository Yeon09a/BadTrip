using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Audio Event Channel")]
public class AudioEventChannelSO : ScriptableObject
{
    public Action<AudioInfoSO, Vector2> audioSourcePlay; // ����� ���

    public Action<AudioInfoSO> audioSourceStop; // ����� ����

    public Func<int, string> getAudioName; // ���� ���� ������� ��µǰ� �ִ°�

    public void RaisePlayEvent(AudioInfoSO audioInfo, Vector2 audioPos)
    {
        audioSourcePlay.Invoke(audioInfo, audioPos);
    }

    public void RaiseStopEvent(AudioInfoSO audioInfo)
    {
        audioSourceStop.Invoke(audioInfo);
    }

    public string RaiseGetAudioName(int num)
    {
        return getAudioName.Invoke(num);
    }
}
