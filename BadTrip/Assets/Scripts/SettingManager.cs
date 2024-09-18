using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public AudioManager audioMng;

    [SerializeField]
    /*private LoadSceneSO backToMainSL_EventChannel;
    [SerializeField]*/
    private SceneInfoSO loadSceneInfo;

    public GameObject settingWindow;
    //public Slider bgmSlider;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private SceneMove sceneMove;



    /*// Start is called before the first frame update
    private void OnEnable()
    {
        backToMainSL_EventChannel.OnLoadingScene += BackToMain;
    }

    private void OnDisable()
    {
        backToMainSL_EventChannel.OnLoadingScene -= BackToMain;
    }*/

    public void SetMasterVol(float v) // ��ü ���� ����
    {
        if (v <= -39f)
        {
            v = -80f;
        }
        
        audioMng.SetGroupVolume("Master", v);
    }
    public void SetBGMVol(float v) // BGM ���� ����
    {
        if (v <= -39f)
        {
            v = -80f;
        }

        audioMng.SetGroupVolume("BGM", v);
    }

    public void SetSFXVol(float v) // SFX ���� ����
    {
        if (v <= -39f)
        {
            v = -80f;
        }

        audioMng.SetGroupVolume("SFX", v);
    }

    public void BackToMain()
    {
        if (!sceneMove.curSceneName.Equals("Main"))
        {
            SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(sceneMove.curSceneName);
            sceneMove.curSceneName = "Main";
            GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfo);
            player.transform.position = new Vector2(31.6f, -9.2f);
            player.GetComponent<Player>().SetAnimLayer(0);
            OnOffSetting(false);
        }
    }

    public void OnOffSetting(bool b)
    {
        settingWindow.SetActive(b);
    }

}
