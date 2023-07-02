using UnityEngine;

public class BuildingSelector : MonoBehaviour
{
    private GameObject selectedBuilding;
    public BuildingInfoPanel infoPanel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Building"))
                {
                    print("Hit");
                    SelectBuilding(hit.transform.gameObject);
                }
                else
                {
                    DeselectBuilding();
                }
            }
            else
            {
                DeselectBuilding();
            }
        }
    }

private void SelectBuilding(GameObject building)
    {
        DeselectBuilding();
        selectedBuilding = building;
        // TODO: Apply outline shader
        // Show info
        BuildingInfo info = FetchBuildingInfo(building.GetComponent<Building>().id);
        infoPanel.ShowInfo(info);
    }

    private void DeselectBuilding()
    {
        if (selectedBuilding != null)
        {
            // TODO: Remove outline shader
            // Hide info
            infoPanel.HideInfo();
            selectedBuilding = null;
        }
    }

    private BuildingInfo FetchBuildingInfo(string uid)
    {
        // For now, return mock data
        return new BuildingInfo
        {
            name = "Building " + uid,
            id = uid,
            area = 234,
            owner = 34,
            price = "345"
        };
    }
}
