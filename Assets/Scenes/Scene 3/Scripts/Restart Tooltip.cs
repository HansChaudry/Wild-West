using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    public TMPro.TMP_Text buttonText;


    private void Start()
    {
        buttonText.text = "Grab to start";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Global.Instance.gameStatus)
        {
            buttonText.text = "Grab to restart";
        }
        else { }
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

}
