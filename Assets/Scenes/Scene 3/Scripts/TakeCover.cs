using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCover : MonoBehaviour
{
    private bool isTakingCover;
    private bool isPlaying;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isTakingCover = false;
        isPlaying = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Global.Instance.gameStatus == true)
        {
            takeCover();
        }
        else
        {
            playPiano();
        }
    }

    private void takeCover()
    {
        if(animator != null)
        {
            animator.ResetTrigger("Play");
            animator.SetTrigger("Duck");
        }
    }

    private void playPiano()
    {
        if (animator != null)
        {
            animator.ResetTrigger("Duck");
            animator.SetTrigger("Play");
        }
    }
}
