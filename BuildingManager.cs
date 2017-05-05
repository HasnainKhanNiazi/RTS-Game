using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {
    public GameObject[] buildings;
    private BuildingPlacement buildingplacement;
	// Use this for initialization
	void Start () {
        buildingplacement = GetComponent<BuildingPlacement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void houseclick()
    {
        buildingplacement.setItems(buildings[0]);
    }

    public void Walls()
    {
        buildingplacement.setItems(buildings[2]);
    }

    public void Stable()
    {
        buildingplacement.setItems(buildings[1]);
    }
}