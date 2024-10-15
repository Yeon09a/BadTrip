using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public class Key_Value<K, V>
{
    public K key;
    public V value;

    public Key_Value(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}

[Serializable] // �̰� �ؾ� inspector â�� ����
public class SerializedDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
{
    [SerializeField]
    List<Key_Value<K, V>> key_value = new();
    
    // ����Ʈ�� ��ųʸ��� ����
    public void OnAfterDeserialize() // ������ȭ �Ŀ� ȣ��(������ȭ �� ��ųʸ��� ����Ʈ�� �ֽŻ���, �� �� ���� �ϰ����� �����ϱ� ���� �۵�)
    {
        // ������ȭ�� �ϰ� �� �� ����Ʈ�� �ٽ� ��ųʸ��� ������ ��
        this.Clear();

        foreach (var pair in key_value)
        {
            var key = pair.key;

            if (this.ContainsKey(key)) // �ν����� â���� �߰��� �� �� ������ �߰��� Ű ���� ���� ���� �߰��Ǿ� ���� Ű ���� �ִٰ� �ν����� â�� �߰����� ����.
            {
                // �ν����� â�� �߰����� �ʴ� ���� �����ϱ� ����
                if (key is string)
                {
                    key = (K)(object)"[Default String Key]";
                }
                else
                {
                    key = default;
                }
            }
            this.Add(key, pair.value);
        }
    }

    // ��ųʸ��� ����Ʈ�� ����
    public void OnBeforeSerialize() // ����ȭ ���� ȣ��(����ȭ ���� ��ųʸ��� ����Ʈ�� ����ȭ)
    {
        // ����ȭ �ϱ� �� ��ųʸ��� ����Ʈ�� �ٲ�� ��.
        key_value.Clear();

        foreach (KeyValuePair<K, V> pair in this) // Dictionary�� ��ӹް� �־� dictionary ó�� �ൿ ����. �׷��Ƿ� this�� ����ϸ� serializedDictionary�� ��� Ű-���� ��ȸ�ϰ� ��.
        {
            key_value.Add(new Key_Value<K, V>(pair.Key, pair.Value));
        }
    }
}
