using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public Text scoreText;                        
    public GameObject gameOvertext;

    private int score = 0;

    public bool gameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Scored(int points, bool spawn)
    {
        if (gameOver)
            return;
        score += points;
        scoreText.text = "Score: " + score.ToString();
        if (spawn)
        {
            PlayerController.instance.UpdateSpeed();
            LaserSpawner.instance.SpawnLaser();
            if (RandomEnemy(1.0f) == true)
            {
                LaserSpawner.instance.SpawnUfo();
            }
        }
    }

    public void Died()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }

    public bool RandomEnemy(float maxRange)
    {
        float fRand = Random.Range(0.0f, maxRange);
        if (fRand <= .3f)
            return true;
        return false;
    }

}