using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _time;
    [SerializeField] TextMeshProUGUI _quests;

    private void Start()
    {
        if (_time != null && _quests != null)
        {
            _time.text = $"Секунд осталось: {PlayerPrefs.GetInt("Time")}";
            int a = 0;
            foreach(Quest q in Resources.LoadAll<Quest>("SO"))
            {
                if (q.isComplite)
                {
                    a++;
                }
            }
            _quests.text = $"Заданий Выполнено: {a}/3";
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
