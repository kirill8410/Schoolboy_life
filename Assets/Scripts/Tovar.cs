using TMPro;
using UnityEngine;

public class Tovar : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Inventory inventory;

    private void Start()
    {
        text.text = $"{item.TextName}\n{item.Price}ð.";
    }

    public void AddTovar()
    {
        inventory.AddProduct(item);
    }
}
