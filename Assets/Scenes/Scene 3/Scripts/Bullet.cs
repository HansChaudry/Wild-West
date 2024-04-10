using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("PlayerBody"))
        //{
            //collision.gameObject.GetComponent<Player>().reduceLife(1);
            //print("hit player");

        //}
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            Component enemyScript = collision.gameObject.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                collision.gameObject.GetComponent<Enemy>().reduceLife(20);
            }
            print("collided with " + collision.gameObject.name);
            Destroy(gameObject);
        }

        
    }
}
