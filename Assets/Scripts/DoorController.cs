using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public bool isLocked = true;
    public AudioSource lockedAudio;
    public AudioSource openAudio;
    
    private bool isOpen = false;
    private bool isAnimating = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = transform.rotation;

        openRotation = 
            Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y + 80f,
                transform.eulerAngles.z
            );
    }

    public void Interact()
    {
        if (isAnimating) return;

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
            StartCoroutine(openDoor());

            // if (openAudio != null) openAudio.Play();
            // transform.rotation = Quaternion.Euler(0, 360, 0);
            // isOpen = true;

            // Debug.Log("Pintu terbuka.");
        }
    }

    IEnumerator openDoor()
    {
        isAnimating = true;

        Quaternion startRot = transform.rotation;

        float time = 0;

        while (time < 1f)
        {
            time += Time.deltaTime * 2f;

            transform.rotation =
                Quaternion.Lerp(
                    startRot,
                    openRotation,
                    time);

            yield return null;
        }

        if (openAudio != null) openAudio.Play();

        isOpen = true;
        isAnimating = false;

        Debug.Log("Pintu terbuka.");
    }

    public void UnlockDoor()
    {
        isLocked = false;

        Debug.Log("Pintu sekarang terbuka!");
    }

    public void ForceCloseDoor()
    {
        transform.rotation = closedRotation;
        isOpen = false;
    }

    public void CloseDoor()
    {
        if (isAnimating) return;
        StartCoroutine(CloseDoorRoutine());
    }

    IEnumerator CloseDoorRoutine()
    {
        isAnimating = true;
        Quaternion startRot = transform.rotation;
        float time = 0;
        while (time < 1f)
        {
            time += Time.deltaTime * 2f;
            transform.rotation = Quaternion.Lerp(
                startRot, closedRotation,
                time
            );
            yield return null;
        }
        
        if (lockedAudio != null) lockedAudio.Play();

        isOpen = false;
        isAnimating = false;
    }
}
