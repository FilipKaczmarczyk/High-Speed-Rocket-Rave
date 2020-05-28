using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D rb;

    private Renderer m_Renderer;

    public bool left = false;

    public bool played = false;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = -transform.up * speed;
        }
        

        if (!m_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
        else
        {
            if (!played)
            {
                AudioManager.instance.PlaySfx(1);
                played = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        if(other.tag == "Player")
        {
            if (PlayerController.instance.CheckIsImmortal() == false)
            {
                GameControl.instance.Died();
            }
        }
    }
}
