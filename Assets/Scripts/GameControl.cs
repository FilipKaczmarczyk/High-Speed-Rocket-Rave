using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public GameObject[] planets;

    public GameObject levelComplete;
    public Animator anim;

    public Text scoreText;
    public Text moneyText;

    public GameObject gameOvertext;
    public GameObject gamewintext;

    public Text levelText;

    public Image dashCooldownImage;
    private float dashCooldownCounter;
    private float dashCooldown;

    private GameObject targetPlanet;
    SpriteRenderer targetPlanetRenderer;

    public static int score = 0;

    public bool gameOver = false;
    public bool gameWin = false;

    public bool levelEnd = false;

    public int dashCost = 100;

    public static int level = 1;

    public bool one = true;

    public static bool slowTime = false;

    public static bool immortality = false;

    public Image immortalityImage;

    public Image slowTimeImage;

    private ParallaxBackground pB;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Instantiate(planets[level - 1], new Vector3(0f, -11.4f, 0f), Quaternion.identity);
        targetPlanet = Instantiate(planets[level], new Vector3(0f, 500f, 0f), Quaternion.identity);
        targetPlanetRenderer = targetPlanet.GetComponent<SpriteRenderer>();

        pB = targetPlanet.GetComponent<ParallaxBackground>();
        pB.enabled = !pB.enabled;

        moneyText.text = PlayerController.money.ToString();
    }

    void Update()
    {
        dashCooldownCounter = PlayerController.instance.dashCooldownCounter;
        dashCooldown = PlayerController.dashCooldown;
        DashCooldown(dashCooldownCounter);

        if (targetPlanetRenderer.isVisible == true)
        {
            levelEnd = true;
        }

        if (levelEnd == true)
        {
            PlayerController.instance.UpdateSpeed(0.998f);
        }

        levelText.text = "Level " + level;

        if (PlayerController.instance.transform.position.y > 490 && one == true)
        {
            if (level == 5)
            {
                AudioManager.instance.WinMusic();
                gamewintext.SetActive(true);
                gameWin = true;
            }
            else
            {
                one = false;
                levelComplete.SetActive(true);
                anim.Play("CompleteFadeOff", 0, 0.25f);
            }
            
        }

        if(immortality == false)
        {
            immortalityImage.color = new Color(immortalityImage.color.r, immortalityImage.color.g, immortalityImage.color.b, 0.2f);
        }
        else
        {
            immortalityImage.color = new Color(immortalityImage.color.r, immortalityImage.color.g, immortalityImage.color.b, 1.0f);
        }

        if (slowTime == false)
        {
            slowTimeImage.color = new Color(slowTimeImage.color.r, slowTimeImage.color.g, slowTimeImage.color.b, 0.2f);
        }
        else
        {
            slowTimeImage.color = new Color(slowTimeImage.color.r, slowTimeImage.color.g, slowTimeImage.color.b, 1.0f);
        }

    }

    void FixedUpdate()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            level = 1;
            PlayerController.money = 0;
            slowTime = false;
            immortality = false;
            score = 0;
            PlayerController.dashCooldown = 2f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (gameWin && Input.GetMouseButtonDown(0))
        {
            level = 1;
            PlayerController.money = 0;
            slowTime = false;
            immortality = false;
            score = 0;
            PlayerController.dashCooldown = 2f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void Scored(int points, bool spawn)
    {
        if (gameOver)
            return;
        score += points;
        scoreText.text = "Score: " + score.ToString();
        if (spawn && levelEnd == false)
        {
            PlayerController.instance.UpdateSpeed(1.02f);

            //LaserSpawner.instance.SpawnLaser();

            if (RandomEnemy(1.0f) == true)
            {
                //LaserSpawner.instance.SpawnUfo();
            }
            if (RandomEnemy(0.5f) == true)
            {
                LaserSpawner.instance.SpawnMoney();
            }
        }
    }

    public void Died()
    {
        AudioManager.instance.GameOverMusic();
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

    public void DashCooldown(float dashCooldownCounter)
    {
        float amount = (dashCooldown - dashCooldownCounter) / dashCooldown;
        dashCooldownImage.fillAmount = amount;
    }

    public void PickUpMoney()
    {
        PlayerController.money += 25;
        moneyText.text = PlayerController.money.ToString();
        AudioManager.instance.PlaySfx(3);
    }

}