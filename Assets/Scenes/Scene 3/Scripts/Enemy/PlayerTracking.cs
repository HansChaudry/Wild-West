using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    
    public Transform playerPos;
    private bool enemyState;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = GetComponentInChildren<Enemy>().isAlive;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == true)
        {
            turnEnemy();
        }
    }

    private void turnEnemy()
    {
        if (playerPos)
        {
            var lookPosition = playerPos.position - transform.position;
            //prevents rotation on the y axis 
            lookPosition.y = 0;
            var rotation = Quaternion.LookRotation(lookPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            Transform body = transform.GetChild(0);
            rotation.y = rotation.y + 0.34f;
            body.transform.rotation = Quaternion.Lerp(body.transform.rotation, rotation, Time.deltaTime);
            enemyState = GetComponentInChildren<Enemy>().isAlive;
        }
    }
}
