using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

public class unit2 : MonoBehaviour
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

    void setTag(String tag)
    {
        transform.tag = tag;
        transform.FindChild("Hips").tag = tag;
        transform.FindChild("Paladin_J_Nordstrom_Sword").tag = "SwordE";
    }
    
	void Start ()
	{
            anim = this.GetComponent<Animator>();
            agent = gameObject.GetComponent<NavMeshAgent>();
            agent.stoppingDistance = 0;
            if (this.gameObject.tag.Equals("Enemy"))
                target = "Ally";
            else
                target = "Enemy";

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
        if (selected == true && Input.GetKey(KeyCode.LeftAlt))
        {
            transform.FindChild("LineOfSight").gameObject.SetActive(true);
        }
        else
        {
           transform.FindChild("LineOfSight").gameObject.SetActive(false);
        }
            GameObject NE = GetNearestEnmy();
            if (NE != null)
            {
                dist = this.transform.position - NE.transform.position;
            }
            if (anim.GetInteger("anim") != 4 && NE != null && forcedToMove != true && dist.magnitude < sightRadious)
            {
                previousDestination = agent.destination;


                destination = NE.transform.position;
                SetDestination(destination);
                if (dist.magnitude < 10)
                {//Enmeys.Length < 3) {
                    LookTowardEnmy();
                    int x = UnityEngine.Random.Range(2, 4);
                    SetAttack(x);
                }
                else
                {
                    SetWalk();
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
		anim.SetInteger ("anim", 0);
	}
	private void SetWalk(){
		anim.SetInteger ("anim", 1);
	}
	private void SetAttack(int x){
		LookTowardEnmy ();
		anim.SetInteger ("anim", x);
		 
	}

	private void SetDestination(Vector3 dest){
	
		if ( dest != Vector3.zero){
			agent.SetDestination (dest);
			LookTowardEnmy ();
		}
	}
	private void LookTowardEnmy(){
		
		if ( destination != Vector3.zero){
			Vector3 direction = destination - this.transform.position;
			direction.y = 0f;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
		}
	}
	private GameObject GetNearestEnmy(){
		GameObject[] gos;
		GameObject closest = null;

		try{
			gos = GameObject.FindGameObjectsWithTag(target);

		} catch(Exception e){
			Debug.Log("GOT NOTHING");
			return closest;
		}

		float distance = Mathf.Infinity;
		Vector3 position = transform.position;

		foreach (GameObject go in gos) {
			//Debug.Log(go.transform.position);
			Vector3 diff = go.transform.position - position;
			float currentDistance = diff.sqrMagnitude;
			if (currentDistance < distance) {
				closest = go;
				distance = currentDistance;
			}
		}
		return closest;
	}
	private bool IsThereEnmyAround(){
		Enmeys = null;
		Enmeys = Physics.OverlapSphere (this.transform.position,sightRadious,1<<findLayer);
		return Enmeys != null;
	}

    IEnumerator WaitForConnection()
    {
        yield return new WaitForSeconds(5);
    }
}