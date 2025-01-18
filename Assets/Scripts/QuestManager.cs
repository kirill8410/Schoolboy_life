using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    [SerializeField] GameObject _questPrefab;

    private void Start()
    {
        foreach (Quest quest in quests)
        {
            quest.isComplite = false;
        }
    }

}
