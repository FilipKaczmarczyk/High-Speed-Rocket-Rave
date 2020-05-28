using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform barrel;

    public void Shoot()
    {
        Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        bulletPrefab.transform.Rotate(0f, 0f, 90f);
    }
}
