using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SmoothHandAnimation : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;
    [SerializeField] private InputActionReference triggerActionRef;
    [SerializeField] private InputActionReference gripActionRef;

    private static readonly int triggerAniamtion = Animator.StringToHash("Trigger");
    private static readonly int gripAniamtion = Animator.StringToHash("Grip");

    private void Update()
    {
        float triggerValue = triggerActionRef.action.ReadValue<float>();
        handAnimator.SetFloat(triggerAniamtion, triggerValue);

        float gripValue = gripActionRef.action.ReadValue<float>();
        handAnimator.SetFloat(gripAniamtion, gripValue);
    }
}
