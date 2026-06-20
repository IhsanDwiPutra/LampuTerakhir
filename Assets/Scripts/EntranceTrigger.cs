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

            frontDoor.CloseAndLock();
        }
    }
}
