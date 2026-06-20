using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public Light targetLight;

    public IEnumerator Flicker()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Flicker ges");
            targetLight.enabled = !targetLight.enabled;

            yield return new WaitForSeconds(
                Random.Range(0.05f, 0.15f)
            );
        }
        targetLight.enabled = true;
    }
}
