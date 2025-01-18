using TMPro;
using UnityEngine;

public class QuestText : MonoBehaviour
{
    private bool _isActive;
    private Quest _quest;
    [SerializeField] private SpriteRenderer _circle;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = _quest.quest;
    }

    public void ChangeActive()
    {
        if (!_isActive)
        {
            _isActive = true;
            _circle.color = new Color(180 / 255, 1, 180 / 255);
        }
        else
        {
            _isActive = false;
            _circle.color = new Color(180 / 255, 0, 0);
        }

    }


}
