using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public float fireRate = 5f;
    public float nextFireTime = 0f;

    void Update()
    {
        if (Gamepad.current.rightTrigger.ReadValue() > 0.1f && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * bulletSpeed;
            }
        }
    }
}
