﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    public Text scoreText;                        
    public GameObject gameOvertext;

    public Image dashCooldownImage;
    private float dashCooldownCounter;
    private float dashCooldown;

    public GameObject targetPlanet;
    SpriteRenderer targetPlanetRenderer;

 /*   public GameObject Planet;
    SpriteRenderer planetRenderer;*/

    private int score = 0;

    public bool gameOver = false;

    public bool levelEnd = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        targetPlanetRenderer = targetPlanet.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dashCooldownCounter = PlayerController.instance.dashCooldownCounter;
        dashCooldown = PlayerController.instance.dashCooldown;
        DashCooldown(dashCooldownCounter);

        if (targetPlanetRenderer.isVisible == true)
        {
            levelEnd = true;
        }

        if (levelEnd == true)
        {
            PlayerController.instance.UpdateSpeed(0.99f);
        }
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
        if (spawn && levelEnd == false)
        {
            PlayerController.instance.UpdateSpeed(1.02f);

            LaserSpawner.instance.SpawnLaser();

            if (RandomEnemy(1.0f) == true)
            {
                //LaserSpawner.instance.SpawnUfo();
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

    public void DashCooldown(float dashCooldownCounter)
    {
        float amount = (dashCooldown - dashCooldownCounter) / dashCooldown;
        dashCooldownImage.fillAmount = amount;
    }

}