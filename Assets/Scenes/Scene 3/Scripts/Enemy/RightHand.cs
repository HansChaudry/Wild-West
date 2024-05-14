using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public GameObject enemyRevolver;
    // Start is called before the first frame update
    void Start()
    {
        //enemyRevolver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Global.Instance.gameStatus == true)
        {
            enemyRevolver.SetActive(true);
        }
        else
        {
            enemyRevolver.SetActive(false);
        }
        
    }
}
