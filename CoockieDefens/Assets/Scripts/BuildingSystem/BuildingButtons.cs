using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtons : MonoBehaviour
{
    BuildingManager buildingManager;
    GameObject currentBuilding;
    Vector3 pos;
    private void Start()
    {
        buildingManager = BuildingManager.instance;
        TakePosition();
    }


    public void PlaceBuilding()
    {
        TakePosition();
        if (currentBuilding == null)
        {
            return;
        }

         Instantiate(currentBuilding, pos, Quaternion.identity);

    }
    public void ChooseBuilding(GameObject buildingPrefab)
    {
        currentBuilding = buildingPrefab;
    }
    private void Update()
    {
        if (currentBuilding != null)
        {
            TakePosition();

        }
    }

    void TakePosition()
    {
        pos = buildingManager.pointToBuild.position;
    }
}
  
