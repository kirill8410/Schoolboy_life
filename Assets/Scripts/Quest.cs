using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
public class Quest : ScriptableObject
{
    public string quest;
    public bool isComplite;
    public QuestText questText;

    public void Complite()
    {
        isComplite = true;
        questText.ChangeActive();
    }
}
