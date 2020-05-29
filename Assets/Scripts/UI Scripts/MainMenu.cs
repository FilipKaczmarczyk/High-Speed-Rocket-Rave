using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectLevel()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
