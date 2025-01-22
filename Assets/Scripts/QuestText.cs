using TMPro;
using UnityEngine;

public class QuestText : MonoBehaviour
{
    public Quest _quest;
    [SerializeField] private SpriteRenderer _circle;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = _quest.quest;
    }

    public void ChangeActive()
    {
        _circle.color = new Color(180 / 255, 1, 180 / 255);
    }


}
