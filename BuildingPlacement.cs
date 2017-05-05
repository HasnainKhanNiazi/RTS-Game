using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {
    private PlaceableBuilding placeable;
    private Transform cureentBuilding;
    Camera camera;
    private bool hasplaced;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cureentBuilding != null && !hasplaced)
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y,transform.position.y);
            Vector3 p = camera.ScreenToWorldPoint(m);
            cureentBuilding.position = new Vector3(p.x, 0, p.z);

            if (Input.GetMouseButtonDown(0))
            {
                if (isLegalPos())
                {
                    hasplaced = true;
                }
            }

        }
	}

    bool isLegalPos()
    {
        if (placeable.colliders.Count > 0)
            return false;
        return true;
    }

    public void setItems(GameObject b)
    {
        hasplaced = false;
        cureentBuilding = ((GameObject)Instantiate(b)).transform;
        placeable = cureentBuilding.GetComponent<PlaceableBuilding>();
    }
}
