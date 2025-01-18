using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    private void Start()
    {
        foreach (Quest quest in quests)
        {
            quest.isComplite = false;
        }
    }

}
