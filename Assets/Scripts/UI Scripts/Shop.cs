using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public Button btn;

    public int price;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (PlayerController.money < price)
        {
            btn.interactable = false;
        }
    }

    public void BuyImmortality()
    {
        if (GameControl.immortality == false)
        {
            PlayerController.money -= 500;
            GameControl.immortality = true;
        }

        btn.interactable = false;
    }

    public void BuyTimeSlow()
    {
        if (GameControl.slowTime == false)
        {
            PlayerController.money -= 250;
            GameControl.slowTime = true;
        }

        btn.interactable = false;

    }

    public void BuyDashSpeed()
    {
        PlayerController.money -= 150;
        PlayerController.dashCooldown -= 0.1f;
    }
}
