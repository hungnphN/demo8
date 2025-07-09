using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval = 1.0f; 
    private float lastBulletTime;

    public Vector3 bulletOffset;

    void Update()
    {
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + bulletOffset, Quaternion.identity);
    }
}