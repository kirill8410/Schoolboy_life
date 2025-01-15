using UnityEngine;

public class StakanWater : MonoBehaviour
{

    public   float water;
    [SerializeField] GameObject water_part;
    [SerializeField] GameObject water_ist;
    [SerializeField] GameObject water_;

    void Update()
    {
        if (this.transform.rotation.x > 0.5f|| this.transform.rotation.x > 0.5f)
        {
            water_part.SetActive(true);
        }
        else
        {
            water_part.SetActive(false);
        }
        if (water_ist.tag == "water"&&water<100f)
        {
            water += 5*Time.deltaTime;
        }
        if (water >= 100)
        {
            water = 100;
        }
        if (water < 70) { water_.transform.localScale = new Vector3(water, water, 2); }
        else
        {
            water_.transform.localScale = new Vector3(water, water, water);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        water_ist = other.gameObject;
    }
}
