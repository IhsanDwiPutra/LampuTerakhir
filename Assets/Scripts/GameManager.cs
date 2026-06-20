using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Switch Progress")]
    public int switchesActivated = 0;
    public DoorController lastRoomDoor;
    public DoorController frontDoor;
    public bool missionComplete = false;
    public AudioSource knockAudio;
    public Light bedroomLight;

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

            lastRoomDoor.UnlockDoor();
        }
    }

    public void FinalSwitchActivated()
    {
        missionComplete = true;

        Debug.Log("Misi selesai");

        if (frontDoor != null)
        {
            frontDoor.UnlockDoor();
        }

        StartCoroutine(PlayKnock());
    }

    IEnumerator PlayKnock()
    {
        yield return new WaitForSeconds(1f);
        knockAudio.Play();
        Debug.Log("Suara ketukan aktif");

        yield return new WaitForSeconds(1f);
        bedroomLight.enabled = true;

        yield return new WaitForSeconds(0.5f);
        bedroomLight.enabled = false;
    }
}
