using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int level;

    public void GoLevel()
    {
        GameControl.level = level;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
