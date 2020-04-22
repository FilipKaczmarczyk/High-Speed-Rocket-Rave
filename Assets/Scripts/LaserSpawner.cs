using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserRightPrefab;
    public GameObject laserLeftPrefab;

    public int laserPoolSize = 5;    

    public float spawnRate = 3f;           
                                 
    private GameObject[] lasers;

    private bool[] directions;

    private int currentLaser = 0;                                    

    private Vector2 objectPoolPosition = new Vector2(-15, -25);  
    
    private float spawnYPosition = 10f;

    private float timeSinceLastSpawned;

    float minSpawnXPosition;

    float maxSpawnXPosition;

    float spawnXPosition;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        lasers = new GameObject[laserPoolSize];

        directions = new bool[laserPoolSize];

        for (int i = 0; i < laserPoolSize; i++)
        {
            var rand = Random.Range(0, 2);

            if (rand == 1)
            {
                directions[i] = false;

                lasers[i] = (GameObject)Instantiate(laserRightPrefab, objectPoolPosition, Quaternion.identity);

            }
            else
            {
                directions[i] = true;

                lasers[i] = (GameObject)Instantiate(laserLeftPrefab, objectPoolPosition, Quaternion.identity);

                lasers[i].transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);

            }

        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            if(directions[currentLaser] == true)
            {
                minSpawnXPosition = -0.7f;

                maxSpawnXPosition = 1.3f;

                spawnXPosition = Random.Range(minSpawnXPosition, maxSpawnXPosition);
            }
            else
            {
                minSpawnXPosition = -1.3f;

                maxSpawnXPosition = 0.7f;

                spawnXPosition = Random.Range(minSpawnXPosition, maxSpawnXPosition);
            }

            lasers[currentLaser].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentLaser++;

            if (currentLaser >= laserPoolSize)
            {
                currentLaser = 0;
            }
        }
    }

}