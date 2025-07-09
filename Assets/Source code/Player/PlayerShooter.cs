using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval;
    private float lastBulletTime;
    public Vector3 bulletOffet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Instantiate(bulletPrefab, transform.position, transform.rotation);
        //}
        //    if (Input.GetMouseButton(0))
        //    {
        //        if (Time.time - lastBulletTime > shootingInterval)
        //        {
        //            ShootBullet();
        //            lastBulletTime = Time.time;
        //        }
        //    }
        //}
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }
    private void UpdateFiring()
    {
        if(Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }
    public AudioClip shootSFX;
    private void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab, transform.position + bulletOffet, transform.rotation);
        AudioSource.PlayClipAtPoint(shootSFX, transform.position);
    }
}
