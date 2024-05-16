using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelLocation;
    public float shotPower = 500f;
    public float minShootInterval = 5f; // Minimum time interval between shots
    public float maxShootInterval = 15f; // Maximum time interval between shots
    public float bulletDamage = 10f; // Damage inflicted by enemy bullet

    private float lastShootTime;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); // Find the PlayerHealth component in the scene
        lastShootTime = Time.time; // Initialize the last shoot time
    }

    void Update()
    {
        if (Time.time - lastShootTime > GetRandomShootInterval())
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        if (bulletPrefab && barrelLocation)
        {
            GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            if (bulletRB != null)
            {
                bulletRB.AddForce(barrelLocation.forward * shotPower);
            }
        }
    }

    // Get a random shoot interval within the specified range
    float GetRandomShootInterval()
    {
        return Random.Range(minShootInterval, maxShootInterval);
    }

    // Check if the bullet hits the player and apply damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(bulletDamage);
            Destroy(gameObject); // Destroy the bullet when it hits the player
        }
    }
}
