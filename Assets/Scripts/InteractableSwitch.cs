using UnityEngine;

public class InteractableSwitch : MonoBehaviour
{
    private bool isActivated = false;

    public bool isFinalSwitch = false;
    public Light targetLight;
    public AudioSource switchAudio;
    public Renderer lampBulbRenderer;
    public Material lampOnMaterial;
    public Material lampOffMaterial;

    public void Interact()
    {
        if (isActivated) return;

        isActivated = true;

        if (targetLight != null)
        {
            targetLight.enabled = false;
        }

        if (switchAudio != null)
        {
            switchAudio.Play();
        }

        if (lampBulbRenderer != null)
        {
            lampBulbRenderer.material = lampOffMaterial;
        }

        Debug.Log(gameObject.name + " diaktifkan!");

        GameManager.Instance.ActivateSwitch();
        if (isFinalSwitch)
        {
            GameManager.Instance.FinalSwitchActivated();
        }

    }
}
