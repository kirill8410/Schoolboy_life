using TMPro;
using UnityEditor;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    [SerializeField] GameObject _questPrefab;
    private GameObject _canvas;


    private void Start()
    {
        _canvas = GetComponentInChildren<Canvas>().gameObject;
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
                GameObject _quest = Instantiate(_questPrefab, _canvas.transform);
                _quest.transform.localPosition = new Vector3(0, (quests.Length - i) * 10f - 20f - (10f * i));
                break;
            }
        }
    }
}
