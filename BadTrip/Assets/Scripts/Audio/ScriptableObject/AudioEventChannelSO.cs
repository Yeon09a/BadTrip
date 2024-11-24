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

    public Action<AudioInfoSO, float> audioSourcePlayFade;

    public Action<float> audioSourceStopFade;

    public Func<int, string> getAudioName; // ���� ���� ������� ��µǰ� �ִ°�

    public Func<int> getCurBGMNum;

    public Action<int> setCurBGMNum;

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

    public void RaisePlayFadeEvent(AudioInfoSO audioInfo, float fade)
    {
        audioSourcePlayFade.Invoke(audioInfo, fade);
    }

    public void RaiseStopFadeEvent(float fade)
    {
        audioSourceStopFade.Invoke(fade);
    }

    public int RaiseGetBGMNum()
    {
        return getCurBGMNum.Invoke();
    }

    public void RaiseSetBGMNum(int num)
    {
        setCurBGMNum.Invoke(num);
    }
}
