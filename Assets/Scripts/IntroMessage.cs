using UnityEngine;
using TMPro;
using System.Collections;

public class IntroMessage : MonoBehaviour
{
    public CanvasGroup introGroup;

    IEnumerator Start()
    {
        introGroup.alpha = 1;

        yield return new WaitForSeconds(4f);

        float t = 0;

        while (t < 2f)
        {
            t += Time.deltaTime;
            introGroup.alpha = Mathf.Lerp(1, 0, t / 2f);
            yield return null;
        }

        introGroup.gameObject.SetActive(false);
    }
}
