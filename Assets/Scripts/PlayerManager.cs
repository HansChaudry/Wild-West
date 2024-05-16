using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // Singleton instance

    public Transform playerTransform; // Reference to the player's transform

    void Awake()
    {
        // Ensure only one instance of the player manager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
