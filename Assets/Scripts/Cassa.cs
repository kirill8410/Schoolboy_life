using UnityEngine;
using UnityEngine.SceneManagement;

public class Cassa : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] QuestManager manager;
    bool[] _isComplite = new bool[5] { false, false, false, false, false };

    public void Pay()
    {
        foreach (Product p in inventory.products)
        {
            if (p != null)
            {
                if (p.item.TextName == "Яица")
                {
                    _isComplite[0] = true;
                }
                else if (p.item.TextName == "Молоко")
                {
                    _isComplite[1] = true;
                }
                else if (p.item.TextName == "Хлеб")
                {
                    _isComplite[2] = true;
                }
                else if (p.item.TextName == "Варенье")
                {
                    _isComplite[3] = true;
                }
                else if (p.item.TextName == "Шоколад")
                {
                    _isComplite[4] = true;
                }
            }
        }
        if (_isComplite[0] && _isComplite[1] && _isComplite[2] && _isComplite[3] && _isComplite[4])
        {
            manager.CompiteQuest(3);
        }
        SceneManager.LoadScene(2);
    }
}
