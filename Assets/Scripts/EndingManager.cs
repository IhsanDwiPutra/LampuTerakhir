using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class EndingManager : MonoBehaviour
{
    public static EndingManager Instance;

    public Image fadePanel;
    public GameObject endingText;

    private void Awake()
    {
        Instance = this;
        fadePanel.color = new Color(0,0,0,0);
        endingText.SetActive(false);
    }

    public void PlayEnding()
    {
        StartCoroutine(EndingRoutine());
    }

    IEnumerator EndingRoutine()
    {
        float t = 0;

        while (t < 2f)
        {
            t += Time.deltaTime;

            float alpha = t /2f;

            fadePanel.color = new Color(0,0,0,alpha);

            yield return null;
        }
        endingText.SetActive(true);
    }
}
