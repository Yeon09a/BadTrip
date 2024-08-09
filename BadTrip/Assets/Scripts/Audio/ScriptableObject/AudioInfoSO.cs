using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Data/AudioInfoSO")]
public class AudioInfoSO : ScriptableObject
{
    public int audioNum; // ����� ��ȣ. �����ϸ� ���� �ʿ� �������� ���� ������� ��� 1 �̳� 2 ���� �۰� ����. ��� ������ ��� 0���� ����, oneShot�� �չ�ȣ
    public AudioClip clip;
    public float vol;
    public float pch = 1;
    public bool isLoop;
    public bool isOneShot;
    public float spread;
    public AudioMixerGroup audioMixerGroup;

    public float spatialBlend = 0; // ���� 2d(0), 3d(1) ����
    public float minDistance = 1f; // �� �Ÿ� �������� �ְ� ���� ����
    public float maxDistance = 500f; // �� �Ÿ� �������� ������ ����, ������ ����� �Ҹ��� �鸮�� ����

    public void ApplyTo(AudioSource audioSource)
    {
        audioSource.clip = this.clip;
        audioSource.volume = vol;
        audioSource.pitch = pch;
        audioSource.loop = isLoop;
        audioSource.spread = this.spread;
        audioSource.outputAudioMixerGroup = audioMixerGroup;

        audioSource.spatialBlend = this.spatialBlend;
        audioSource.minDistance = this.minDistance;
        audioSource.maxDistance = this.maxDistance;
    }
}
