using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public ParticleSystem bloodSplatterFX;
    public Enemy enemyScript; // Reference to the Enemy script

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, Vector3 contactPoint)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die(contactPoint); // Call Die method with the contact point
        }
        else
        {
            SpawnBloodSplatter(contactPoint);
        }
    }

    void SpawnBloodSplatter(Vector3 contactPoint)
    {
        // Spawn the blood splatter effect at the contact point
        ParticleSystem effect = Instantiate(bloodSplatterFX, contactPoint, Quaternion.identity);
        effect.Stop();
        effect.Play();
    }

    void Die(Vector3 hitPosition)
    {
        // Call ragdoll setup and death methods
        enemyScript.SetupRagdoll();
        enemyScript.Dead(hitPosition);
        // Destroy the enemy GameObject
        //Destroy(gameObject);
    }
}
