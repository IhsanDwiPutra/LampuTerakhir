using UnityEngine;

public class BedroomFlickerTrigger : MonoBehaviour
{
    public LightFlicker flicker;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            StartCoroutine(flicker.Flicker());
        }
    }
}
