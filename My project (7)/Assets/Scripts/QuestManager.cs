using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                 instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject newGameObject = new GameObject("QuestManager");
                    instance = newGameObject.AddComponent<QuestManager>();
                }
            }

            return instance;
        }
        set
        {
         
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject); 
        }
        instance = this;
    }
}
