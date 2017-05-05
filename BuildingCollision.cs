using UnityEngine;
using System.Collections;

/// <summary>
/// Building collision.
/// 
/// This script is attached to the buildings.
/// </summary>

public class BuildingCollision : MonoBehaviour {
	
    private bool isCollided = false;
	public bool Collided()
    {
        return isCollided;
    }

    private BuildManager buildMan = null;

    void Start()
    {
        buildMan = GameObject.Find("BuildManager").GetComponent<BuildManager>();
    }
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag != buildMan.TerrainCollisionTag)
		{
            isCollided = true;
		}
	}

	void OnCollisionExit()
	{
        isCollided = false;
	}
}
