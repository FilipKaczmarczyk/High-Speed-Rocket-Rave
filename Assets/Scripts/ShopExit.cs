using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopExit : MonoBehaviour
{
    public Animator anim;

    public GameObject levelChanger;

    public Text textLevel;

    public static int levelShop = 1;

    public void ExitShop()
    {
        levelShop ++;
        GameControl.level++;
        levelChanger.SetActive(true);
        anim.Play("ShopFadeOut", 0, 0.25f);
    }

    void Update()
    {
        textLevel.text = "Level " + GameControl.level;
    }
}
