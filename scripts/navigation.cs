using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navigation : MonoBehaviour
{
	//Transform destinationPoint;
	private Vector3 pos;
	private bool canMove = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			locatePosition ();
		}
		if (canMove == true) {
			move ();
		}
	}

	void locatePosition ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit, 1000)) {
			pos = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
			Debug.Log (pos);
			canMove = true;
			print (canMove);
		}

	}

	void move ()
	{
		//Quaternion newRotation = Quaternion.LookRotation (pos - transform.position); //, Vector3.forward);
//		newRotation.x = 0f;
//		newRotation.z = 0f;
		//transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.fixedDeltaTime = 10);
		transform.GetComponent<NavMeshAgent> ().destination = pos;
	}
}