using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject settingsmenu;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsMenu()
    {
        menu.SetActive(false);
        settingsmenu.SetActive(true);
    }

    public void Back()
    {
        settingsmenu.SetActive(false);
        menu.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}