using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    private void Update()
    {
        int progress = GameManager.Instance.switchesActivated;

        string task1 = progress >= 1 ? "[x]" : "[ ]";
        string task2 = progress >= 2 ? "[x]" : "[ ]";
        string task3 = progress >= 3 ? "[x]" : "[ ]";

        objectiveText.text = 
            "Tugas:\n\n" +
            $"{task1} Matikan saklar ruang tamu\n" +
            $"{task2} Matikan saklar dapur\n" +
            $"{task3} Matikan saklar kamar belakang";
    }
}
