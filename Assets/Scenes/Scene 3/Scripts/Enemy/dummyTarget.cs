using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyTarget : MonoBehaviour
{
    private int health;
    public Material material;

    void Start()
    {
        health = 100;
        material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            material.color = Color.red;
        }
    }

    public void reduceLife(int damage)
    {
        health -= damage;
    }
}
