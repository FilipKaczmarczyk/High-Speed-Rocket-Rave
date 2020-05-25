using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    public static LaserSpawner instance;

    public GameObject laserRightPrefab;
    public GameObject laserLeftPrefab;
    public GameObject UfoPrefab;
    public GameObject UfoPrefab2;
    public GameObject MoneyPrefab;
                            
    float minSpawnXPosition;

    float maxSpawnXPosition;

    float spawnXPosition;

    float spawnYPostion = 40f;

    public int count = 0;

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
        var block = Random.Range(0, 4);

        if (block == 1)
        {
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnLeftLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if(GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
            SpawnLeftLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnLeftLaser();
            spawnYPostion += 10f;
            SpawnRightLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
        }
        else if (block == 2)
        {
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
        }
        else if (block == 3)
        {
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnLeftLaser();
            spawnYPostion += 10f;
            SpawnRightLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnRightLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
        }
        else if (block == 4)
        {
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnRightLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnRightLaser();
            spawnYPostion += 10f;
            SpawnRightLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
            SpawnLeftLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 3)
            {
                spawnYPostion -= 5f;
                SpawnUfo(2);
                spawnYPostion += 5f;
            }
            SpawnLeftLaser();
            spawnYPostion += 10f;
            SpawnLeftLaser();
            spawnYPostion += 10f;
            if (GameControl.level >= 2)
            {
                spawnYPostion -= 5f;
                SpawnUfo(1);
                spawnYPostion += 5f;
            }
        }

        count++;

        if(count < 10)
        {
            SpawnLaser();
        }
    }

    public void SpawnLeftLaser()
    {
        if(spawnYPostion <= 490)
        {
            minSpawnXPosition = -1.3f;
            maxSpawnXPosition = 0.7f;

            spawnXPosition = Random.Range(minSpawnXPosition, maxSpawnXPosition);

            GameObject laser = Instantiate(laserLeftPrefab, new Vector3(spawnXPosition, spawnYPostion, 0f), Quaternion.identity);

            laser.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }
    }

    public void SpawnRightLaser()
    {
        if (spawnYPostion <= 490)
        {
            minSpawnXPosition = -0.7f;
            maxSpawnXPosition = 1.3f;

            spawnXPosition = Random.Range(minSpawnXPosition, maxSpawnXPosition);

            GameObject laser = Instantiate(laserRightPrefab, new Vector3(spawnXPosition, spawnYPostion, 0f), Quaternion.identity);
        }
    }

    public void SpawnUfo(int level)
    {
        if (spawnYPostion <= 490)
        {
            if (level == 1)
            {
                Instantiate(UfoPrefab, new Vector3(0, spawnYPostion, 0f), Quaternion.identity);
            }
            else if (level == 2)
            {
                Instantiate(UfoPrefab2, new Vector3(0, spawnYPostion, 0f), Quaternion.identity);
            }
            else if (level == 3)
            {

            } 
        }
    }

    public void SpawnMoney()
    {
        var rand = Random.Range(0, 3);

        float x = 0;

        if(rand == 1)
        {
            x = -1.7f;
        }
        if (rand == 2)
        {
            x = 0.0f;
        }
        if (rand == 3)
        {
            x = 1.7f;
        }

        Instantiate(MoneyPrefab, new Vector3(x, PlayerController.instance.transform.position.y + 15f, 0f), Quaternion.identity);
    }
}