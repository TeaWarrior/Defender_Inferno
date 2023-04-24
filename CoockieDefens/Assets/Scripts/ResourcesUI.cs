using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI woodText;
    
    ResourcesManager resourcesManager;
    public GameObject ResourcesPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        resourcesManager = ResourcesManager.instance;
        resourcesManager.OnChangeResources += ResourcesManager_OnChangeResources;
    }

    private void ResourcesManager_OnChangeResources(object sender, System.EventArgs e)
    {
        RefreshWood();
    }

    void RefreshWood()
    {
        woodText.text = resourcesManager.Wood.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resourcesManager.AddWood(10);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!ResourcesPanel.activeSelf)
            {
                ResourcesPanel.SetActive(true);
            }
            else
            {
                ResourcesPanel.SetActive(false);
            }
            
        }
    }
}
