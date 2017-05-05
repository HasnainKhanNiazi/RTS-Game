using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;
using UnityEngine.Networking;

public class unitcannon : MonoBehaviour
{
	private bool selected = false;
	private bool forcedToMove=false;
	private bool selectedByClick = false;
	private float distance;
	private int findLayer;
	private String target;
	private Vector3 previousDestination;
	private Vector3 destination;
	public Collider[] Enmeys;
	public float sightRadious=5f;
	public float attackRang = 3f;
	float turnSpeed = 5.0f;
	Vector3 dist;
	Animator anim;
	NavMeshAgent agent;

	private Vector3 moveToDest = Vector3.zero;
	// Use this for initialization
    
	void Start ()
	{
            agent = gameObject.GetComponent<NavMeshAgent>();
            agent.stoppingDistance = 0;

	}
//	// Update is called once per frame
    protected void Update()
	{
        
        if (selected == true)
        {
            transform.FindChild("SelectionCircle").gameObject.SetActive(true);
        }
        else
        {
            transform.FindChild("SelectionCircle").gameObject.SetActive(false);
        }

        if (transform.tag != "cannon" && transform.tag!="barrel")
        {
            if (selected == true && Input.GetKey(KeyCode.LeftAlt))
            {
                transform.FindChild("LineOfSight").gameObject.SetActive(true);
            }
            else
            {
                transform.FindChild("LineOfSight").gameObject.SetActive(false);
            }
        }


		
		if (GetComponent<Renderer> ().isVisible && Input.GetMouseButton (0)) {

			if (!selectedByClick) {
				Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
				camPos.y = cameraOperater.invertMouseY (camPos.y);
				selected = cameraOperater.selection.Contains (camPos);
                
			}
		}
		if (selected && Input.GetMouseButton (1)) {  
                destination = cameraOperater.getDestination();
                forcedToMove = true;
                SetDestination(destination);
                SetWalk();
		}
		if (forcedToMove && agent.remainingDistance < 1) {
			forcedToMove = false;
			SetIdle ();
		}
	}

	private void OnMouseUp ()
	{
		if (selectedByClick) {
			selected = true;
		}
		selectedByClick = false;
	}

	private void OnMouseDown ()
	{
		selectedByClick = true;
		selected = true;
	}
	private void SetIdle(){
        //anim.SetInteger ("anim", 0);
	}
	private void SetWalk(){
        transform.Translate(0,0,5);
	}

	private void SetDestination(Vector3 dest){
	
		if ( dest != Vector3.zero){
			agent.SetDestination (dest);
		}
	}
	

    IEnumerator WaitForConnection()
    {
        yield return new WaitForSeconds(5);
    }
}