using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class unit : MonoBehaviour
{
    public Text enemyspotted_text;
	public bool selected = false;
	public float floorOffset = 1f;
	private bool selectedByClick = false;
	private float distance;
    public LayerMask mask;
	private string findTag;
    private float radius = 15f;
    public Collider[] coll;
	//public GameObject selectionGlow = null;
	//private GameObject glow = null;
	Animator anim;
	NavMeshAgent agent;

	private Vector3 moveToDest = Vector3.zero;
	// Use this for initialization
	void Start ()
	{
		anim = this.GetComponent<Animator>();
		agent = gameObject.GetComponent<NavMeshAgent> ();
		if (this.tag == "Ally")
			findTag = "Enemy";
            
		else
			findTag = "Ally";
	}
	
	// Update is called once per frame
    void Update()
    {
        //Vector3 destination=GameObject.FindGameObjectsWithTag(findTag)[0].transform.position;
        if (GetComponent<Renderer>().isVisible && Input.GetMouseButton(0))
        {

            if (!selectedByClick)
            {
                Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
                camPos.y = cameraOperater.invertMouseY(camPos.y);
                selected = cameraOperater.selection.Contains(camPos);
            }
        }
        if (selected && Input.GetMouseButton(1))
        {
            Vector3 destination = cameraOperater.getDestination();
            //Vector3 destinat=GameObject.FindGameObjectsWithTag(findTag)[0].transform.position;
            float dist = agent.remainingDistance;

            if (destination != Vector3.zero)
            {
              //  Quaternion newRotation = Quaternion.LookRotation(destination - transform.position); //, Vector3.forward);
                //newRotation.x = 0f;
                //newRotation.z = 0f;
                //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.fixedDeltaTime = 10);
                agent.SetDestination(destination);
                agent.stoppingDistance = 1;
                moveToDest = destination;
                moveToDest.y += floorOffset;
                SetWalk();
            }
        }

        if (!anim.GetBool("isIdle") && agent.remainingDistance <= 3)
        {
            if (cameraOperater.checktag == "Enemy")
            {
                print("Atttackkkkkkkkkkkkkkk");
                SetAttack();
            }

        }
        if (agent.remainingDistance <= 0.2f)
            SetIdle();

        coll = Physics.OverlapSphere(transform.position, radius, mask);
        if (coll.Length >= 1)
        {
            enemyspotted_text.text = "Enemys Are around you ... Be CareFul";
        }
        else if (coll.Length < 1)
        {
            enemyspotted_text.text = "";
        }
        if (selected == true)
        {
            transform.FindChild("SelectionCircle").gameObject.SetActive(true);
        }
        else
        {
            transform.FindChild("SelectionCircle").gameObject.SetActive(false);
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
		anim.SetBool ("isIdle", true);
		anim.SetBool ("isWalking", false);
		anim.SetBool ("isAttacking",false);
	}
	private void SetWalk(){
		anim.SetBool ("isIdle", false);
		anim.SetBool ("isWalking", true);
		anim.SetBool ("isAttacking",false);
	}
	private void SetAttack(){
		anim.SetBool ("isIdle", false);
		anim.SetBool ("isWalking", false);
		anim.SetBool ("isAttacking",true);
	}

}