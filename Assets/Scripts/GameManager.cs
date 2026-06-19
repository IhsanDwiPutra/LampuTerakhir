using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Switch Progress")]
    public int switchesActivated = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ActivateSwitch()
    {
        switchesActivated++;

        Debug.Log("Switch Aktif: " + switchesActivated);

        if (switchesActivated >= 2)
        {
            Debug.Log("Kamar terakhir terbuka!");
        }
    }
}
