using UnityEngine;

public class Baket : MonoBehaviour
{
    [SerializeField] int clothes;
    [SerializeField] GameObject TargetObj;
    private Quest _actionTarget; //замени SomeMonoBehavior  на название скрипта

    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<Quest>();
    }
    private void Update()
    {
        if (clothes == 0)
        {
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
