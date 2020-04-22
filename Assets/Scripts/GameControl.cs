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

    public float scrollSpeed = -2f;

    float maxScrollSpeed = -2f;

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

        if(score >= 5)
        {
            maxScrollSpeed = -4f;
        }
        if (score >= 10)
        {
            maxScrollSpeed = -6f;
        }
        
        if(scrollSpeed > maxScrollSpeed)
        {
            scrollSpeed -= 0.002f;
        }
    }

    public void Scored()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void Died()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }

}