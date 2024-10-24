using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPrint : MonoBehaviour
{
    public List<QuestData> QuestData;

     void Start()
    {
        for (int i = 0; i < QuestData.Count; i++)
        {
            QuestData currentQuest = QuestData[i];
            Debug.Log($"Quest {currentQuest.QuestNPC} - {currentQuest.QuestName} (최소레벨{currentQuest.QuestRequiredLevel})");
        }
    }
}
