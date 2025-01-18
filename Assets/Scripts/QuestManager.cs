using TMPro;
using UnityEditor;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    [SerializeField] GameObject _questPrefab;

    private void Start()
    {
        Quest[] q = Resources.LoadAll<Quest>("SO");
        foreach (Quest quest in q)
        {
            quest.isComplite = false;
        }
    }

    public void AddQuest(Quest quest)
    {
        for(int i = 0; i < quests.Length; i++)
        {
            if (quests[i] == null)
            {
                quests[i] = quest;

                break;
            }
        }
    }
}
