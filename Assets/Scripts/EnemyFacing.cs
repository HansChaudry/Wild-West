using UnityEngine;

public class EnemyFacing : MonoBehaviour
{
    void Update()
    {
        // Check if player manager instance exists and has a valid player transform
        if (PlayerManager.Instance != null && PlayerManager.Instance.playerTransform != null)
        {
            // Get the direction from the enemy to the player
            Vector3 direction = (PlayerManager.Instance.playerTransform.position - transform.position).normalized;

            // Calculate the rotation needed to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            // Apply the rotation to make the enemy face the player (only rotating on the Y-axis)
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
