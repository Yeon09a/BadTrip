using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string path;
    private string fileName = "SaveDataFile";
    
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Scripts/JsonFile/";
    }

    public void SaveData(JsonData jsonData, bool pretty = false) // �����ϱ�
    {
        string data = JsonUtility.ToJson(jsonData, pretty);
        //File.WriteAllText(path + fileName + eventNum, data);
        // eventNum : ���൵ �� �����͸� �����ϱ� ���� ��ȣ
        // �Ŀ� �˸°� ���� ����
    }

    public JsonData LoadData(int eventNum) // �ҷ�����
    {
        // �Ŀ� ���� ����
        string loadData = File.ReadAllText(path + fileName + eventNum);
        JsonData jsonData = JsonUtility.FromJson<JsonData>(loadData);
        return jsonData;
    }
}
