using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move()
    {
        transform.position += new Vector3(0f, 0.0555f, 0f);
    }
}
