using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int life = 100;
    Animator animator;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.Instance.gameStatus)
        {
            aim();
        }
    }
    public void reduceLife(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            die();
        }
    }
    private void die()
    {
        animator.SetTrigger("Death");
        isAlive = false;
        var enemyGun = GetComponentInChildren<EnemyGun>();
        if (enemyGun != null)
        {
            enemyGun.enabled = false;
        }
    }

    private void aim()
    {
        animator.SetTrigger("Aim");
    }
}
