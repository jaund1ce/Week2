using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    // ���� ������Ʈ Ǯ�� �����ϴ� Dictionary
    public Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();
    public int poolSize = 300;

    // Ǯ �ʱ�ȭ �޼���
    public void InitializePool(string key, GameObject prefab)
    {
        if (!pools.ContainsKey(key))
        {
            List<GameObject> objectPool = new List<GameObject>();

            // ������Ʈ�� Ǯ�� �߰��ϰ� ��Ȱ��ȭ ���·� �ʱ�ȭ
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false); 
                objectPool.Add(obj); 
            }

            pools.Add(key, objectPool);
        }
    }

    // Ư�� Ű�� Ǯ���� ������Ʈ ��������
    public GameObject Get(string key)
    {
        if (pools.ContainsKey(key))
        {
            foreach (GameObject obj in pools[key])
            {
                if (!obj.activeInHierarchy) // ��Ȱ��ȭ�� ������Ʈ ã��
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            // ��� ������Ʈ�� ��� ���� ��� null ��ȯ
            return null;
        }

        return null;
    }

    public void Release(string key, GameObject obj)
    {
        if (pools.ContainsKey(key))
        {
            obj.SetActive(false); // ��Ȱ��ȭ
        }
    }
}
