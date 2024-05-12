using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public AudioSource music;

    // Update is called once per frame
    void LateUpdate()
    {
        if(Global.Instance.gameStatus)
        {
            music.Pause();
        }
    }
}
