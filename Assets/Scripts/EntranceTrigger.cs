using System.Collections;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour
{
    public DoorController frontDoor;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            frontDoor.CloseDoor();
            StartCoroutine(LockDoorAfterClose());
        }
    }

    IEnumerator LockDoorAfterClose()
    {
        yield return new WaitForSeconds(0.6f);
        
        frontDoor.isLocked = true;
        Debug.Log("Pintu depan terkunci");
    }
}
