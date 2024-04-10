using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootDelay = 3f;
    [Range(0, 3000), SerializeField] private float bulletSpeed;
    [Space, SerializeField] private AudioSource audioSource;
    private float lastShot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lastShot >= 3f && lastShot > Time.time) return;
        lastShot = Time.time + shootDelay;

        GunShotAudio();

        var bulletPrefab = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        var bulletRB = bulletPrefab.GetComponent<Rigidbody>();
        var direction = bulletPrefab.transform.TransformDirection(Vector3.forward);
        //direction.y = Random.Range(-0.2f, 0.2f);

        bulletRB.AddForce(direction * bulletSpeed);
        Destroy(bulletPrefab, 5f);
    }


    private void GunShotAudio()
    {
        var random = Random.Range(0.8f, 1.2f);
        audioSource.pitch = random;
        audioSource.Play();
    }

}
