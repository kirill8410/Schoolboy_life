using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests = new Quest[4];
    public QuestText[] questText = new QuestText[4];
    [SerializeField] GameObject _questPrefab;
    [SerializeField] Transform _c;
    private GameObject _canvas;
    [SerializeField] GameObject _camera;
    [SerializeField] private InputActionProperty _aButton;

    private void Start()
    {
        _canvas = GetComponentInChildren<Canvas>().gameObject;
        _canvas.SetActive(false);
        Quest[] q = Resources.LoadAll<Quest>("SO");
        foreach (Quest quest in q)
        {
            quest.isComplite = false;
        }
        AddQuest(Resources.Load<Quest>("SO/Quest1"));
        StartCoroutine(AButton());
    }
    private void Update()
    {
        if (_canvas.active)
        {
            _c.transform.position = _camera.transform.position;
            _c.transform.rotation = new Quaternion(0, _camera.transform.rotation.y, 0, 0);
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

    IEnumerator AButton()
    {
        while (true)
        {
            if (_aButton.action.IsInProgress())
            {
                if (!_canvas.active)
                {
                    _canvas.SetActive(true);
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    _canvas.SetActive(false);
                    yield return new WaitForSeconds(3f);
                }
            }
            yield return null;
        }
    }
}
