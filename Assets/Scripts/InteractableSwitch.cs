using UnityEngine;

public class InteractableSwitch : MonoBehaviour
{
    private bool isActivated = false;

    public void Interact()
    {
        if (isActivated) return;

        isActivated = true;

        Debug.Log(gameObject.name + " diaktifkan!");

        GameManager.Instance.ActivateSwitch();
    }
}
