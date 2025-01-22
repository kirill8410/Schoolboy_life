using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests = new Quest[4];
    public QuestText[] questText = new QuestText[4];
    [SerializeField] GameObject _questPrefab;
    private GameObject _canvas;
    [SerializeField] GameObject _camera;
    [SerializeField] private InputActionProperty _aButton;

    private void Start()
    {
        _canvas = GetComponentInChildren<Canvas>().gameObject;
        _canvas.GetComponent<Canvas>().enabled = false;
        Quest[] q = Resources.LoadAll<Quest>("SO");
        foreach (Quest quest in q)
        {
            quest.isComplite = false;
        }
        AddQuest(Resources.Load<Quest>("SO/Quest1"));
    }
    private void Update()
    {
        if (_aButton.action.IsPressed())
        {
            _canvas.GetComponent<Canvas>().enabled = !_canvas.GetComponent<Canvas>().enabled;
        }
        if (_canvas.GetComponent<Canvas>().enabled)
        {
            _canvas.transform.position = new Vector3(
                _camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z + 1.6f
                );
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
                _quest.transform.localPosition = new Vector3(0, (quests.Length - i) * 20f - 40f);
                _quest.GetComponent<QuestText>()._quest = quest;
                questText[i] = _quest.GetComponent<QuestText>();
                break;
            }
        }
    }
    public void CompiteQuest(int questNumber)
    {
        questText[questNumber].ChangeActive();
        quests[questNumber].isComplite = true;
    }
}
