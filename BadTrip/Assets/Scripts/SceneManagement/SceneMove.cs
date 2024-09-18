using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public Animator transition;
    public SerializedDictionary<string, SceneInfoSO> loadSceneInfos = new SerializedDictionary<string, SceneInfoSO>();
    public SerializedDictionary<string, Vector3> loadPlayerPos = new SerializedDictionary<string, Vector3>(); // �� �̵� �� �÷��̾� ��ġ key : ����� �̸� + �̵��� �� �̸� value : ��ǥ�� �÷��̾ �ٶ󺸴� ���� 1 : �������� �ٶ�. 0 : ������ �ٶ�
    public string curSceneName = "Main";

    [SerializeField]
    private LoadSceneSOAll sceneload_EventChannel;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private PlayerDataSO playerDataSO;

    private void OnEnable()
    {
        sceneload_EventChannel.OnLoadingScene += LoadScene;
    }
    private void OnDisable()
    {
        sceneload_EventChannel.OnLoadingScene -= LoadScene;
    }

    public void LoadScene(string moveSceneName)
    {
        StartCoroutine(LoadSceneCor(moveSceneName));
    }

    IEnumerator LoadSceneCor(string moveSceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(moveSceneName, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(curSceneName);
        GameObject.FindGameObjectWithTag("SceneSetting").GetComponent<SceneSetting>().SetScene(loadSceneInfos[moveSceneName]);
        if(!curSceneName.Equals("Main")){
            player.transform.position = new Vector2(loadPlayerPos[curSceneName + moveSceneName].x, loadPlayerPos[curSceneName + moveSceneName].y);

            if (loadPlayerPos[curSceneName + moveSceneName].z >= 0.5)
            {
                player.GetComponent<SpriteRenderer>().flipX = true; // ������ �ٶ�
            } else if(loadPlayerPos[curSceneName + moveSceneName].z <= 0.1)
            {
                player.GetComponent<SpriteRenderer>().flipX = false; // ���� �ٶ�
            }
        }
        player.SetActive(true);
        curSceneName = moveSceneName;
        yield return new WaitForSeconds(1.0f);
        transition.SetTrigger("End");
        GlobalVariables.variables["playerName"].SetValue(playerDataSO.playerName);
    }
}
