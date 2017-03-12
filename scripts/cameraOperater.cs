using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraOperater : MonoBehaviour
{
    public Texture2D selectionHighlight = null;
	public static Rect selection = new Rect (0, 0, 0, 0);
	private Vector3 startClick = -Vector3.one;
    public static string checktag;

	private static Vector3 moveToDestination = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		checkCamera ();
		cleanUp();
	}

	private void checkCamera ()
	{
		if (Input.GetMouseButtonDown (0)) {
			startClick = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			startClick = -Vector3.one;
		}

		if (Input.GetMouseButton (0)) {
			selection = new Rect (startClick.x, invertMouseY (startClick.y), Input.mousePosition.x - startClick.x,
				invertMouseY (Input.mousePosition.y) - invertMouseY (startClick.y));
                
			if (selection.width < 0) {
				selection.x += selection.width;
				selection.width = -selection.width;
			}
			if (selection.height < 0) {
				selection.y += selection.height;
				selection.height = -selection.height;
			}
		}


	}

	private void OnGUI ()
	{
		if (startClick != -Vector3.one) {
			GUI.color = new Color (1, 1, 1, 0.5f);
			GUI.DrawTexture (selection, selectionHighlight);
		}
	}

	public static float invertMouseY (float y)
	{
		return Screen.height - y;
	}

	private void cleanUp ()
	{
		if (!Input.GetMouseButtonUp (0)) {
			moveToDestination = Vector3.zero;
		}
	}

	public static Vector3 getDestination ()
	{
		if (moveToDestination == Vector3.zero) {
			RaycastHit hit;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (r, out hit,1000)) {
				moveToDestination = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
				Debug.Log ("hit tag: " + hit.transform.tag);
                checktag = hit.transform.tag;
			}
		}
		return moveToDestination;
	}
}