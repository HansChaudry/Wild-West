using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance { get; private set; }
    public bool gameStatus;
    public GameObject player; 

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        gameStatus = false;
    }

    public void startGame()
    {
        gameStatus = true;
    }
}
