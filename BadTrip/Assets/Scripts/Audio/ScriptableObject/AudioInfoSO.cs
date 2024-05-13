using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Data/AudioInfoSO")]
public class AudioInfoSO : ScriptableObject
{
    public int audioNum; // ����� ��ȣ. �����ϸ� ���� �ʿ� �������� ���� ������� ��� 1 �̳� 2 ���� �۰� ����. ��� ������ ��� 0���� ����
    public AudioClip clip;
    public float vol;
    public bool isLoop;
    public AudioMixerGroup audioMixerGroup;

    public float spatialBlend; // ���� 2d(0), 3d(1) ����
    public float minDistance; // �� �Ÿ� �������� �ְ� ���� ����
    public float maxDistance; // �� �Ÿ� �������� ������ ����, ������ ����� �Ҹ��� �鸮�� ����

    public void ApplyTo(AudioSource audioSource)
    {
        audioSource.clip = this.clip;
        audioSource.volume = vol;
        audioSource.loop = isLoop;
        audioSource.outputAudioMixerGroup = audioMixerGroup;

        audioSource.spatialBlend = this.spatialBlend;
        audioSource.minDistance = this.minDistance;
        audioSource.maxDistance = this.maxDistance;
    }
}
