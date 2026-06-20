using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isLocked = true;
    public AudioSource lockedAudio;
    public AudioSource openAudio;
    
    private bool isOpen = false;

    public void Interact()
    {
        if (isLocked)
        {
            if (lockedAudio != null)
            {
                lockedAudio.Play();
            }
            Debug.Log("Pintu terkunci.");
            return;
        }

        if (!isOpen)
        {
            if (openAudio != null) openAudio.Play();
            transform.rotation = Quaternion.Euler(0, 360, 0);
            isOpen = true;

            Debug.Log("Pintu terbuka.");
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;

        Debug.Log("Pintu sekarang terbuka!");
    }

    public void CloseAndLock()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        isOpen = false;

        isLocked = true;

        Debug.Log("Pintu depan terkunci.");
    }
}
