using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static void EndGame()
    {
        Application.Quit();
    }

    public static void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void DisplayPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public static void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
