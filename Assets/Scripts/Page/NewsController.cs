using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class NewsController : MonoBehaviour
{
    NewsItem[] newsItems;
    public GameObject contentPanel;  // A reference to the content panel.
    public GameObject newsItemPrefab;    // A reference to a prefab representing a single news item.

    public void DisplayNews(NewsItem[] newsItems)
    {
        // First, clear out any existing items in the list.
        foreach (Transform child in contentPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Then, add a new item to the list for each piece of news.
        foreach (NewsItem newsItem in newsItems)
        {
            GameObject newItem = Instantiate(newsItemPrefab, contentPanel.transform);
            //TextMeshProUGUI[] textComponents = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            //TextMeshProUGUI titleTextComponent = textComponents[0];
            //TextMeshProUGUI descriptionTextComponent = textComponents[1];

            //titleTextComponent.text = newsItem.title;
            //descriptionTextComponent.text = newsItem.description;
        }
    }

    IEnumerator GetNewsFromAPI()
    {
        string url = "http://your-api-url.com";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // On successful response, process the data.
                ProcessJsonData(www.downloadHandler.text);
            }
        }
    }

    void Start()
    {
#if UNITY_EDITOR
        // Use mock data in development mode
        newsItems = GetMockData();
        DisplayNews(newsItems);
#else
    // Get data from API in production mode
    StartCoroutine(GetNewsFromAPI());
#endif
    }

    private NewsItem[] GetMockData()
    {
        return new NewsItem[]
        {
        new NewsItem() { title = "Mock Title 1", description = "Mock Description 1" },
        new NewsItem() { title = "Mock Title 2", description = "Mock Description 2" },
            // Add more mock data as needed.
        };
    }

    void Update()
    {

    }

    public void ProcessJsonData(string jsonData)
    {
        newsItems = JsonHelper.FromJson<NewsItem>(jsonData);
    }
}
