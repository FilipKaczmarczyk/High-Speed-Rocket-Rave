using UnityEngine;
using System.Collections;
 
 public class PlayerController : MonoBehaviour
 {
    public GameObject rocket;

    public Vector3 startPos;

    private Vector3 endPos;

    private float distance = 1.875f;

    private float lerpTime = 0.4f;

    private float currentLerpTime = 0f;

    private bool keyHit = false;

    private float attackDistance = 0.5f;

    private float lerpAttackTime = 0.05f;

    private float currentLerpAttackTime = 0f;

    private bool keyAttackHit = false;

    private bool canClick = true;

    public CameraController cn;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("left") && canClick)
        {
            keyHit = true;
            canClick = false;
            SetPosition(Vector3.left);
            StartCoroutine(WaitAfterMove());
        }
        else if (Input.GetKeyDown("right") && canClick)
        {
            keyHit = true;
            canClick = false;
            SetPosition(Vector3.right);
            StartCoroutine(WaitAfterMove());
        }
        /*else if (Input.GetKeyDown("up") && canClick)
        {
            keyAttackHit = true;
            canClick = false;
            SetAttackPosition();
            StartCoroutine(WaitAfterAttack());
        }*/

        if (GameControl.instance.gameOver != true)
        {
            if (keyHit)
            {
                currentLerpTime += Time.deltaTime;
                if (currentLerpTime >= lerpTime)
                {
                    currentLerpTime = lerpTime;
                }

                float Perc = currentLerpTime / lerpTime;
                rocket.transform.position = Vector3.Lerp(startPos, endPos, Perc);
            }

            if (keyAttackHit)
            {
                currentLerpAttackTime += Time.deltaTime;
                if (currentLerpAttackTime >= lerpAttackTime)
                {
                    currentLerpAttackTime = lerpAttackTime;
                }

                float Perc = currentLerpAttackTime / lerpAttackTime;
                rocket.transform.position = Vector3.Lerp(startPos, endPos, Perc);
            }
        }
        else
        {
            rocket.transform.position = rocket.transform.position;
        }

    }

    IEnumerator WaitAfterMove()
    {
        yield return new WaitForSeconds(lerpTime);
        canClick = true;
        keyHit = false;
        currentLerpTime = 0;
    }

    IEnumerator WaitAfterAttack()
    {
        yield return new WaitForSeconds(lerpAttackTime);
        canClick = true;
        keyAttackHit = false;
        currentLerpAttackTime = 0;
        cn.Move();
    }

    void SetPosition(Vector3 a)
    {
        startPos = rocket.transform.position;
        endPos = rocket.transform.position + a * distance;
    }

    void SetAttackPosition()
    {
        startPos = rocket.transform.position;
        endPos = rocket.transform.position + Vector3.up * attackDistance;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //GameControl.instance.Died();
    }

}   


