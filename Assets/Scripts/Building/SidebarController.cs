using UnityEngine;
using UnityEngine.UI;

public class SidebarController : MonoBehaviour
{
    public GameObject panel;
    public GameObject overlap;
    public OverlapController overlapController; // assign in inspector
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenSidebar()
    {
        overlapController.onClick.AddListener(HideSidebar);
        overlap.GetComponent<Image>().color = new Color(0, 0, 0, .5f);
        overlap.SetActive(true);
        animator.SetBool("isOpen", true);
    }

    public void HideSidebar()
    {
        overlapController.onClick.RemoveListener(HideSidebar);
        overlap.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        overlap.SetActive(false);
        animator.SetBool("isOpen", false);
    }

    public void ToggleSidebar()
    {
        if (animator.GetBool("isOpen"))
        {
            HideSidebar();
        }
        else
        {
            OpenSidebar();
        }
    }
}
