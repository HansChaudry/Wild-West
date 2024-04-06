using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Revolver : Weapon
{
    [SerializeField] private Projectile bulletPrefab;

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }

    protected override void Shoot()
    {
        base.Shoot();
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }
}
