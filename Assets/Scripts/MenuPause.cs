using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject _menuPause;
    [SerializeField] private GameObject _settings;
    private static bool MenuPaused = false;


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (MenuPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1f;
        MenuPaused = false;
    }

    public void Pause()
    {
        _menuPause.SetActive(true);
        Time.timeScale = 0f;
        MenuPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Settings()
    {
        _settings.SetActive(true);
        _menuPause.SetActive(false);
    }

    public void BackFromSettings()
    {
        _settings.SetActive(false);
        _menuPause.SetActive(true);
    }
}
