using System;
using UnityEngine;

public class StakanWater : MonoBehaviour
{

    public   float water;
    [SerializeField] GameObject water_part;
    [SerializeField] GameObject water_ist;
    [SerializeField] GameObject water_;
    [SerializeField] int _type;
    [SerializeField] GameObject TargetObj;
    private QuestManager _actionTarget; //замени SomeMonoBehavior  на название скрипта
    bool wat;
    public void Start()
    {
        _actionTarget = TargetObj.GetComponent<QuestManager>();
    }
    void Update()
    {
        if (this.transform.rotation.x > 0.5f && water > 0 || this.transform.rotation.x < -0.5f&&water>0|| this.transform.rotation.z > 0.5f && water > 0 || this.transform.rotation.z < -0.5f && water > 0)
        {
            water_part.SetActive(true);
            water -= 10 * Time.deltaTime;
            if (_type == 0)
            {
                water_.transform.localScale = new Vector3((65 + 35 * water / 100) / 100, water / 100, (65 + 35 * water / 100) / 100);
            }
            if (_type == 1)
            {
                water_.transform.localScale = new Vector3(1, water / 100, 1);
            }
            
        }
        else
        {
            water_part.SetActive(false);
        }
        if ((water_ist.tag == "water"&&water<100f)||( water_ist.tag == "dogm" && water < 100f))
        {
            water += 10*Time.deltaTime;
        }
        if (water > 100)
        {
            water = 100;
        }
        if(water < 0)
        {
            water = 0;
        }
        if (_type== 0)
        {
            water_.transform.localScale = new Vector3((65 + 35 * water / 100) / 100, water / 100, (65 + 35 * water / 100) / 100);
        }
        if (_type == 1)
        {
            water_.transform.localScale = new Vector3(1, water / 100, 1);
        }
        if (_type == 1&& water == 100)
        {
            _actionTarget.CompiteQuest(2);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "water"|| other.tag == "dogm")
        {
            water_ist = other.gameObject;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "water" || other.tag == "dogm")
        {
            water_ist = null;
        }
    }
}
