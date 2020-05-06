using UnityEngine;
using System.Collections;
 
 public class PlayerController : MonoBehaviour
 {
    public static PlayerController instance;

    [SerializeField]
    private Transform playerDashEffect;

    public float rotationSpeed = 3f;
    public float speed = 2f;

    float currentSpeed;

    public bool dash = false;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(GameControl.instance.gameOver == false)
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

            if (Input.GetKeyDown("space"))
            {
                StartCoroutine(Dash(angle));
            }
        }
       
    }
    public void UpdateSpeed()
    {
        speed *= 1.02f;
    }

    private IEnumerator Dash(float x)
    {
        currentSpeed = speed;
        dash = true;
        speed = currentSpeed * 10;
        yield return new WaitForSeconds(0.09f);
        Vector3 beforeDashPos = transform.position;
        yield return new WaitForSeconds(0.01f);
        speed = currentSpeed;
        Instantiate(playerDashEffect, beforeDashPos, Quaternion.AngleAxis(x - 90f, Vector3.forward));
        dash = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Laser" || (other.collider.tag == "Enemy" && dash == false) || other.collider.tag == "MainCamera")
            GameControl.instance.Died();
    }

}   


