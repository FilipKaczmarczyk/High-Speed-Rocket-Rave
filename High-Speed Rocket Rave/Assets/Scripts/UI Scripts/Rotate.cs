using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    float speed = 7f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, -speed);
    }
}
