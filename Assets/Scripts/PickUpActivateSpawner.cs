using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUpActivateSpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    private bool hasActivated;

    private void Start()
    {
        // Nothing
    }

    private void OnEnable()
    {
        // Subscribe to the onSelectEntered event of the weapon's XRGrabInteractable component
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(ActivateSpawner);
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from the onSelectEntered event when disabled
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.RemoveListener(ActivateSpawner);
        }
    }

    private void ActivateSpawner(XRBaseInteractor interactor)
    {
        // Reactivate the spawner only if it hasn't been activated before
        if (!hasActivated && spawner != null)
        {
            spawner.hasStartedSpawn = true; // Directly set hasStartedSpawn to true
        }
    }
}
