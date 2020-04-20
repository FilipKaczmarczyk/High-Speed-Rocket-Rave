using UnityEngine;
using System.Collections;
 
 public class PlayerController : MonoBehaviour
 {

    private Vector2 playerPosition;

    private void Start()
    {
        playerPosition = transform.position;
    }

    void Update()
    {
        Debug.Log(playerPosition.x);
        playerPosition = transform.position;
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown("left") && playerPosition.x == 0.0f)
        {
            transform.position = new Vector2(-1.8f, transform.position.y);
            playerPosition = transform.position;
        }
        else if (Input.GetKeyDown("left") && playerPosition.x == -1.8f)
        {
            transform.position = new Vector2(1.8f, transform.position.y);
            playerPosition = transform.position;
        }
        else if (Input.GetKeyDown("left") && playerPosition.x == 1.8f)
        {
            transform.position = new Vector2(0.0f, transform.position.y);
            playerPosition = transform.position;
        }
        else if (Input.GetKeyDown("right") && playerPosition.x == 0.0f)
        {
            transform.position = new Vector2(1.8f, transform.position.y);
            playerPosition = transform.position;
        }
        else if (Input.GetKeyDown("right") && playerPosition.x == -1.8f)
        {
            transform.position = new Vector2(0.0f, transform.position.y);
            playerPosition = transform.position;
        }
        else if (Input.GetKeyDown("right") && playerPosition.x == 1.8f)
        {
            transform.position = new Vector2(-1.8f, transform.position.y);
            playerPosition = transform.position;
        }
    }
}
