using UnityEngine;

public class StakanWater : MonoBehaviour
{

    public   float water;
    [SerializeField] GameObject water_part;
    [SerializeField] GameObject water_ist;
    [SerializeField] GameObject water_;
    bool wat;

    void Update()
    {
        if (this.transform.rotation.x > 0.5f && water > 0 || this.transform.rotation.x > 0.5f&&water>0)
        {
            water_part.SetActive(true);
            water -= 10 * Time.deltaTime;
            water_.transform.localScale = new Vector3((65 + 35 * water / 100) / 100, water / 100, (65 + 35 * water / 100) / 100);
        }
        else
        {
            water_part.SetActive(false);
        }
        if (water_ist.tag == "water"&&water<100f)
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
        water_.transform.localScale = new Vector3((65 + 35 * water / 100) / 100, water / 100, (65 + 35 * water / 100) / 100);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "water")
        {
            water_ist = other.gameObject;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "water")
        {
            water_ist = null;
        }
    }
}
