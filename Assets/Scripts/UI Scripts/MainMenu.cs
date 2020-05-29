using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject credits;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectLevel()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void BackFromLevelSelect()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void BackFromCredits()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
