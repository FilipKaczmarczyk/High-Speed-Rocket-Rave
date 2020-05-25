using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;

    public bool direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float fRand = Random.Range(0.0f, 1.0f);
        if (fRand <= .5f)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }
    }

    void Update()
    {

        if (direction) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = !direction;

        if(collision.collider.tag == "Player" && PlayerController.instance.dash == true)
        {
            Destroy(gameObject);
            GameControl.instance.Scored(5, false);
        }
    }

}
