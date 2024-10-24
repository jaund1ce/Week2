using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="QuestDataSo",menuName = "QuestDataSo/MonsterQuestDataSO", order = int.MaxValue)]
public class QuestData : ScriptableObject
{
    [SerializeField]
    private string questName;
    public string QuestName { get { return questName; } }
    [SerializeField]
    private int questRequiredLevel;
    public int QuestRequiredLevel { get { return questRequiredLevel; } }
    [SerializeField]
    private int questNPC;
    public int QuestNPC { get { return questNPC; } }
    [SerializeField]
    private List<int> questPrerequisites;
    public List<int> QuestPrerequisites { get { return questPrerequisites; } }
}
