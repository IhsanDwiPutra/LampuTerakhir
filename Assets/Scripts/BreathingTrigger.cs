using UnityEngine;

public class BreathingTrigger : MonoBehaviour
{
    public AudioSource breathingSource;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (!GameManager.Instance.missionComplete) return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;

            breathingSource.Play();
            Debug.Log("Suara Bernapas");
        }
    }
}
