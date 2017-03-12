using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
	private float speed = 40;
	private float zoomSpeed = 32.0f;
    private float ScrollSpeed = 30;
    private float ScrollEdge = 0.01f;
	// checking inside
	float curDistance = 6;
	//
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge))
        {
            transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if (Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge)
        {
            transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -ScrollSpeed, Space.World);
        }

		RaycastHit hit;
		if (Physics.Raycast (transform.position, -transform.forward, out hit, 1000)) {
			//find current distance
			curDistance = Vector3.Distance (transform.position, hit.point);
		}

		Debug.Log (curDistance);
//		if (curDistance < 5) {

			if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				GetComponent<Transform> ().position = new Vector3 (transform.position.x, transform.position.y - 6f, transform.position.z + 2f);
				//transform.Rotate(-0.1f,0,0);

			}
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				GetComponent<Transform> ().position = new Vector3 (transform.position.x, transform.position.y + 6f, transform.position.z - 2f);
				//transform.Rotate(-0.1f,0,0);

			}
//		}
	}
}
