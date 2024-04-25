using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public AudioSource shootingSound;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;
    public float fireRate = 5f;
    public float nextFireTime = 0f;

    void Update()
    {
        // Shooting for Player1 with the controller's right trigger
        if (gameObject.name == "Player" && Gamepad.current != null &&
            Gamepad.current.rightTrigger.ReadValue() > 0.1f && Time.time >= nextFireTime)
        {
            Shoot();
        }

        // Shooting for Player2 with the spacebar
        else if (gameObject.name == "Player2" && Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shootingSound.Play();
        nextFireTime = Time.time + 1f / fireRate;
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }
}
