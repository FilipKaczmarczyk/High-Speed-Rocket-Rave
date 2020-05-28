using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] levelMusics;

    public AudioSource gameOverMusic, winMusic;

    public AudioSource[] sfx;

    public int currentMusic = 0;

    public bool gamePlay = true;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentMusic = Random.Range(0, 7);
        levelMusics[currentMusic].Play();
    }

    void Update()
    {
        if (gamePlay)
        {
            if (!levelMusics[currentMusic].isPlaying)
            {
                if (currentMusic == levelMusics.Length - 1)
                {
                    currentMusic = 0;
                }
                else
                {
                    currentMusic++;
                }
                levelMusics[currentMusic].Play();
            }
        } 
    }

    public void GameOverMusic()
    {
        if (gamePlay)
        {
            gamePlay = false;
            levelMusics[currentMusic].Stop();
            gameOverMusic.Play();
        }
    }

    public void WinMusic()
    {
        if (gamePlay)
        {
            gamePlay = false;
            levelMusics[currentMusic].Stop();
            winMusic.Play();
        }
    }

    public void PlaySfx(int sound)
    {
        sfx[sound].Stop();
        sfx[sound].Play();
    }
}
