using UnityEngine;

public class Baket : MonoBehaviour
{
    [SerializeField] int clothes;
    [SerializeField] MonoBehaviour script;
    GameObject TargetObj; //не забудь перетащить в инспекторе сюда нужный обьект
    private SomeMonoBehavior _actionTarget; //замени SomeMonoBehavior  на название скрипта

    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<SomeMonoBehavior>();
    }
    private void Update()
    {
        if (clothes == 0)
        {
            _actionTarget.Method();
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
