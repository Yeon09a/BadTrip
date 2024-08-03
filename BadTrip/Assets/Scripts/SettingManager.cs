using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public AudioManager audioMng;

    [SerializeField]
    private LoadSceneSO backToMainSL_EventChannel;
    private SceneInfoSO loadSceneInfo;



    // Start is called before the first frame update
    private void OnEnable()
    {
        backToMainSL_EventChannel.OnLoadingScene += BackToMain;
    }

    private void OnDisable()
    {
        backToMainSL_EventChannel.OnLoadingScene -= BackToMain;
    }

    public void SetMasterVol(float v) // ��ü ���� ����
    {
        audioMng.SetGroupVolume("Master", v);
    }
    public void SetBGMVol(float v) // BGM ���� ����
    {
        audioMng.SetGroupVolume("BGM", v);
    }

    public void SetSFXVol(float v) // SFX ���� ����
    {
        audioMng.SetGroupVolume("SFX", v);
    }

    public void BackToMain()
    {
        SceneManager.LoadSceneAsync("School", LoadSceneMode.Additive); // ���� �� �ҷ�����
        SceneManager.UnloadSceneAsync("BadTrip");
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
    }
}
