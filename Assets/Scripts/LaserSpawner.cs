using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    public static LaserSpawner instance;

    public GameObject laserRightPrefab;
    public GameObject laserLeftPrefab;
    public GameObject UfoPrefab;
                                 
    private bool direction;                                

    float minSpawnXPosition;

    float maxSpawnXPosition;

    float spawnXPosition;

    float spawnYPostion = 10f;
    void Start()
    {
        instance = this;
        SpawnLaser();
    }

    void Update()
    {
        
    }

    public void SpawnLaser()
    {
        var rand = Random.Range(0, 2);

        if (rand == 1)
        {
            direction = false;

            minSpawnXPosition = -0.7f;

            maxSpawnXPosition = 1.3f;

            spawnXPosition = Random.Range(minSpawnXPosition, maxSpawnXPosition);
        }
        else
        {
            direction = true;

            minSpawnXPosition = -1.3f;

            maxSpawnXPosition = 0.7f;

            spawnXPosition = Random.Range(minSpawnXPosition, maxSpawnXPosition);
        }

        if (!direction)
        {
            GameObject laser = Instantiate(laserRightPrefab, new Vector3(spawnXPosition, spawnYPostion, 0f), Quaternion.identity);
        }
        else
        {
            GameObject laser = Instantiate(laserLeftPrefab, new Vector3(spawnXPosition, spawnYPostion, 0f), Quaternion.identity);

            laser.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }

        spawnYPostion += 15f;

    }

    public void SpawnUfo()
    {
        Instantiate(UfoPrefab, new Vector3(0, PlayerController.instance.transform.position.y + 22f, 0f), Quaternion.identity);
    }
}