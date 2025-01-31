using TMPro;
using UnityEngine;

public class Product : MonoBehaviour
{
    public Item item;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (item != null)
        {
            text.text = item.TextName;
        }
        else
        {
            text.text = "---";
        }
    }


}
