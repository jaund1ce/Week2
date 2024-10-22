using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    // 여러 오브젝트 풀을 관리하는 Dictionary
    public Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();
    public int poolSize = 300;

    // 풀 초기화 메서드
    public void InitializePool(string key, GameObject prefab)
    {
        if (!pools.ContainsKey(key))
        {
            List<GameObject> objectPool = new List<GameObject>();

            // 오브젝트를 풀에 추가하고 비활성화 상태로 초기화
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false); 
                objectPool.Add(obj); 
            }

            pools.Add(key, objectPool);
        }
    }

    // 특정 키의 풀에서 오브젝트 가져오기
    public GameObject Get(string key)
    {
        if (pools.ContainsKey(key))
        {
            foreach (GameObject obj in pools[key])
            {
                if (!obj.activeInHierarchy) // 비활성화된 오브젝트 찾기
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            // 모든 오브젝트가 사용 중일 경우 null 반환
            return null;
        }

        return null;
    }

    public void Release(string key, GameObject obj)
    {
        if (pools.ContainsKey(key))
        {
            obj.SetActive(false); // 비활성화
        }
    }
}
