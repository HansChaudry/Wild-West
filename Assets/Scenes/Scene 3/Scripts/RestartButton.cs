using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public Animator animator;
    public GameObject global;

    public void triggerAnimation()
    {
        animator.SetTrigger("Press");
    }
    public void RestartGame()
    {
        if (Global.Instance.gameStatus)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Global.Instance.startGame();
        }
        
    }
    public void ButtonAudio()
    {
        audioSource.Play();
    }
}
