using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoPanel : MonoBehaviour
{
    public GameObject panel; // assign in inspector
    public Text nameText; // assign in inspector
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowInfo(BuildingInfo info)
    {
        nameText.text = info.name;
        //panel.SetActive(true);
        animator.SetBool("isOpen", true);
    }

    public void HideInfo()
    {
        animator.SetBool("isOpen", false);
        //panel.SetActive(false); // Set panel to active
    }

}
