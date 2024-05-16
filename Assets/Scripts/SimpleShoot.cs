using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;
    public AudioSource source;
    public AudioClip fireSound;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    public void PullTheTrigger()
    {
        gunAnimator.SetTrigger("Fire");
    }

    void Shoot()
    {
        // Play audio, create muzzle flash, etc. 
        source.PlayOneShot(fireSound);

        if (muzzleFlashPrefab)
        {
            // Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            // Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        // Cancel if there's no bullet prefab
        if (!bulletPrefab)
        { 
            return; 
        }

        // Create a bullet
        GameObject bulletObject = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);

        // Set the damage value of the bullet directly
        float bulletDamage = 25f;
    
        // Apply force to the bullet
        bulletObject.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

         // Apply damage directly to the object hit by the bullet (if applicable)
        RaycastHit hit;
        if (Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hit, Mathf.Infinity))
        {
            var hitObject = hit.collider.gameObject;
            var enemyHealth = hitObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Pass the damage and contact point to the enemy's TakeDamage method
                enemyHealth.TakeDamage(bulletDamage, hit.point);
            }
        }
    }


    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}

