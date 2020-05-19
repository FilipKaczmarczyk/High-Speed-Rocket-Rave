using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    public Button btn;

    private int playermoney;

    public int price;

    private void Start()
    {
        playermoney = PlayerController.instance.money;
    }

    private void Update()
    {
        if (playermoney < price)
        {
            btn.interactable = false;
        }
    }
}
