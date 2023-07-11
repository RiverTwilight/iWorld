using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RouteManager : MonoBehaviour
{
    private Dictionary<string, GameObject> routes = new Dictionary<string, GameObject>();


    public GameObject mapPagePrefab;
    public GameObject newsPagePrefab;
    public GameObject aboutPagePrefab;
    public GameObject servicePagePrefab;

    public UnityEvent CloseSidebar;

    // Start is called before the first frame update
    void Start()
    {
        // Populate the routes dictionary
        routes.Add("Map", mapPagePrefab);
        routes.Add("News", newsPagePrefab);
        routes.Add("About", aboutPagePrefab);
        routes.Add("Service", servicePagePrefab);

        foreach (var route in routes.Values)
        {
            route.SetActive(false);
        }
    }

    // Navigate to the specified route
    public void NavigateTo(string routeName)
    {
        CloseSidebar.Invoke();
        // Check if the route name exists
        if (routes.ContainsKey(routeName))
        {
            // Deactivate all other routes
            foreach (var route in routes.Values)
            {
                route.SetActive(false);
            }

            // Activate the desired route
            routes[routeName].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Route " + routeName + " does not exist.");
        }
    }
}
