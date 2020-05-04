using UnityEngine;
using System.Collections;
 
 public class PlayerController : MonoBehaviour
 {
    public float rotationSpeed = 3f;
    public float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 rotTarget = transform.position;

        if (Input.GetKey("right"))
        {
            rotTarget.x += 8;
            rotTarget.y += 3;
        }
        if (Input.GetKey("left"))
        {
            rotTarget.x -= 4;
            rotTarget.y += 3;
        }
        else
        {
            rotTarget.y += 3;
        }

        Vector2 direction = rotTarget - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //GameControl.instance.Died();
    }

}   


