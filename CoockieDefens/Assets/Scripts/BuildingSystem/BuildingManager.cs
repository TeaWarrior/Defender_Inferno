using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public List<GameObject> buildings;
    private GameObject buildingToPlace;
    public Transform pointToBuild;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one BUILDA mANGER");
            return;
        }
        instance = this;
    }


    private void Start()
    {
        buildingToPlace = buildings[0];
    }

    public GameObject GetBuilding()
    {
        return buildingToPlace;
    }
}
