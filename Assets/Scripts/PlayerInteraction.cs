using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = playerCamera.ScreenPointToRay(
                new Vector3(Screen.width / 2f, Screen.height / 2f));
            
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                InteractableSwitch switchObj = hit.collider.GetComponentInParent<InteractableSwitch>();

                DoorController door = hit.collider.GetComponentInParent<DoorController>();

                if (door != null)
                {
                    door.Interact();
                }

                if (switchObj != null)
                {
                    switchObj.Interact();
                }
            }
        }
    }
}
