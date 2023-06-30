using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoPanel : MonoBehaviour
{
    public GameObject panel; // assign in inspector
    public Text infoText; // assign in inspector

    public void ShowInfo(string info)
    {
        infoText.text = info;
        panel.SetActive(true);
    }

    public void HideInfo()
    {
        panel.SetActive(false);
    }
}
