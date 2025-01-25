using UnityEngine;

public class Bambuk : MonoBehaviour
{
    [SerializeField] GameObject TargetObj;
    private QuestManager _actionTarget; //замени SomeMonoBehavior  на название скрипта

    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<QuestManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "water")
        {
            _actionTarget.CompiteQuest(1);
        }
    }
}
