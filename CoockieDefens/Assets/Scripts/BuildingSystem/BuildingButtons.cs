using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtons : MonoBehaviour
{
    BuildingManager buildingManager;
    GameObject currentBuilding;
    private void Start()
    {
        buildingManager = BuildingManager.instance;
    }


    public void PlaceBuilding()
    {
        Vector3 pos = buildingManager.pointToBuild.position;

         Instantiate(currentBuilding, pos, Quaternion.identity);

    }
    public void ChooseBuilding(GameObject buildingPrefab)
    {
        currentBuilding = buildingPrefab;
    }
}
  
