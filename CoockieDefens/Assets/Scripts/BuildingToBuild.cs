using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingToBuild : MonoBehaviour
{
    public GameObject buildingPrefab;
     Material defaultMaterial;
    public MeshRenderer meshRenderer;
    public Material notEnabledToBuild;
    bool isAbleToBuild;
    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = meshRenderer.material;
        
    }

    // Update is called once per frame
   
    private void OnTriggerStay(Collider other)
    {
        if (other == null)
        {
            if (isAbleToBuild)
            {
                isAbleToBuild = false;
                meshRenderer.material = notEnabledToBuild;
            }

        }
        else
        {
            if (!isAbleToBuild)
            {
                isAbleToBuild = true;
                meshRenderer.material = defaultMaterial;
            }
        }
    }
}
