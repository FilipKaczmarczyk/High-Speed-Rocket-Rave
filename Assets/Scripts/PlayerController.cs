using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
 {
    public static PlayerController instance;

    [SerializeField]
    private Transform playerDashEffect;

    public float rotationSpeed = 3f;
    public float speed = 2f;

    float currentSpeed;

    public bool dash = false;
    public static float dashCooldown = 2f;
    public float dashCooldownCounter = 0f;

    public static int money = 1000;

    private bool immortal = false;
    private bool timeSlow = false;

    private SpriteRenderer sr;

    void Start()
    {
        instance = this;
        sr = gameObject.GetComponent<SpriteRenderer>();  
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

            if (timeSlow)
            {
                transform.Translate(Vector2.up * speed/2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            

            if (Input.GetKeyDown("space") && dashCooldownCounter <= 0)
            {
                StartCoroutine(Dash(angle));
            }

            if (Input.GetKeyDown("z") && GameControl.immortality == true)
            {
                GameControl.immortality = false;
                StartCoroutine(Immortality());
            }

            if (Input.GetKeyDown("x") && GameControl.slowTime == true)
            {
                GameControl.slowTime = false;
                StartCoroutine(TimeSlow());
            }

            if (dashCooldownCounter > 0)
            {
                dashCooldownCounter -= Time.deltaTime;
                if(dashCooldownCounter < 0)
                {
                    dashCooldownCounter = 0;
                }
            }
        }

    }
    public void UpdateSpeed(float updateValue)
    {
        speed *= updateValue;
    }

    private IEnumerator Dash(float x)
    {
        currentSpeed = speed;
        dash = true;
        speed = currentSpeed * 5;
        yield return new WaitForSeconds(0.09f);
        Vector3 beforeDashPos = transform.position;
        yield return new WaitForSeconds(0.01f);
        speed = currentSpeed;
        Instantiate(playerDashEffect, beforeDashPos, Quaternion.AngleAxis(x - 90f, Vector3.forward));
        dash = false;
        dashCooldownCounter = dashCooldown;
    }

    private IEnumerator Immortality()
    {
        immortal = true;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        yield return new WaitForSeconds(5f);
        immortal = false;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1.0f);
    }

    private IEnumerator TimeSlow()
    {
        timeSlow = true;
        yield return new WaitForSeconds(10f);
        timeSlow = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Laser" || (other.collider.tag == "Enemy" && dash == false) || other.collider.tag == "MainCamera")
        {
            if (immortal == false)
            {
                GameControl.instance.Died();
            }
        }
            
    }

    public float GetDashCooldown()
    {
        return dashCooldownCounter;
    }

}   


