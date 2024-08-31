using UnityEngine;

public class MapInteractionSetting : MonoBehaviour
{
    public GameObject[] interactionObjs; // ��ȣ�ۿ��� �� �ִ� ������Ʈ��
    public int sceneNum;
    [SerializeField] private InteractionObjectsSO interactionObjectsSO;
    
    [SerializeField]
    private LoadSceneSOAll sceneload_EventChannel;

    private void Awake()
    {
        interactionObjectsSO.interactionObjs.Clear();


        for (int i = 0; i < interactionObjs.Length; i++)
        {
            interactionObjectsSO.interactionObjs.Add(i + sceneNum, interactionObjs[i]);
        }

        interactionObjectsSO.RaiseEvent();
    }

    public void GoScene(string moveSceneName)
    {
        sceneload_EventChannel.RaiseEvent(moveSceneName);
    }

}
