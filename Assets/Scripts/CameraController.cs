using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        if(target != null)
        {
            Vector3 targetPos = target.transform.position + offset;
            Vector3 newPos = Vector2.Lerp(transform.position, targetPos, speed); 
            transform.position = new Vector3(0f, newPos.y, -1f);
        }
    }

}
