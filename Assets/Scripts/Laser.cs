using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null && other.transform.position.x > -3.3 && other.transform.position.x < 3.3
            && other.transform.position.y >= -4.5 && other.transform.position.y < -2.5)
        {
            GameControl.instance.Scored();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.x > -3.3 && other.transform.position.x < 3.3 
            && other.transform.position.y >= -4.5 && other.transform.position.y < -2.5)
        {
            GameControl.instance.Died();
        }
    }
}
