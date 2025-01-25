using UnityEngine;

public class Baket : MonoBehaviour
{
    [SerializeField] int clothes;
    [SerializeField] GameObject TargetObj;
    private QuestManager _actionTarget; //замени SomeMonoBehavior  на название скрипта

    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<QuestManager>();
    }
    private void Update()
    {
        if (clothes == 2)
        {
            _actionTarget.CompiteQuest(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "clothes")
        {
            clothes += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "clothes")
        {
            clothes -= 1;
        }
    }
}
