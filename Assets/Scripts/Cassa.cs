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
            for (int i = 1; i <= 5; i++)
            {
                if (p.item == Resources.Load<Item>($"Products/Item{i}"))
                {
                    _isComplite[i-1] = true;
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
