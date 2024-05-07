using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MachineGun : Weapon
{
    [SerializeField] private float fullAutoDuration; // Duration of full auto fire
    [SerializeField] private Projectile bulletPrefab; // Projectile prefab to be spawned
    [SerializeField] private float spreadAngle = 3f; // Spread angle in degrees
    [SerializeField] private float firingSpeedModifier = 0.5f; // Firing speed modifier

    private bool isFiring; // Flag to track if the machine gun is currently firing
    private float autoFireTimer; // Timer for full auto fire duration

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);

        isFiring = true;
        autoFireTimer = fullAutoDuration;

        // Call the Shoot method immediately upon starting shooting
        Shoot();
    }

    void Update()
    {
        if (isFiring)
        {
            autoFireTimer -= Time.deltaTime;
            if (autoFireTimer <= 0)
            {
                StopShooting(null);
            }
            else
            {
                Shoot();
            }
        }
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);

        isFiring = false;
    }

    protected override void Shoot()
    {
        base.Shoot();

        // Calculate a random spread angle within the specified range
        Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f);

        // Apply spread to the bullet's rotation
        Quaternion bulletRotation = bulletSpawn.rotation * spreadRotation;

        // Spawn a new projectile instance
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletRotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();

        // Halve the firing speed
        autoFireTimer -= Time.deltaTime * firingSpeedModifier;
    }
}
