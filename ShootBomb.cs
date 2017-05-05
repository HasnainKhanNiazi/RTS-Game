using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBomb : MonoBehaviour {

	// Use this for initialization
	Vector3 destination;
	public Transform spherePoint;
	public float sightRadious;
	float previousdistace;
	NavMeshAgent agent;
	GameObject barrel;
	GameObject fire;
	public bool isCannon=false;
	public float velocity=20;
	public string projectileName = "bomb 1";
	private AudioClip clip;
	private AudioSource player;
	private Animator anim;
	public Collider[] enemies=null;
	float timeCounter=0;
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (timeCounter > 1) {
			timeCounter = -3;
			Debug.Log (IsThereEnmyAround (spherePoint.position));
			if (IsThereEnmyAround (spherePoint.position)) {
				Debug.Log ("Enmy FOund...");
				GameObject enmy = GetNearestEnmyPosition ();

				if (enmy.tag == "Player")
					Shoot (enmy.transform.position);
			}

		}
		timeCounter += Time.deltaTime;
	}
	void setToShoot(){
		anim.SetBool ("shoot",true);
		anim.SetBool ("idle",false);
	}
	void setToIdle(){
		anim.SetBool ("shoot",false);
		anim.SetBool ("idle",true);
	}

	IEnumerator waittt(){
		yield return new WaitForSeconds (5);
	}
	void Shoot(Vector3 destination){
		
		transform.LookAt (new Vector3(destination.x,transform.position.y,destination.z));

		GameObject brl=null;
		if (projectileName == "arrow") {
			anim = gameObject.GetComponent<Animator> ();
			setToShoot ();
			//brl = transform.Find ("Game_engine/Root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/" +
			//	"lowerarm_l/hand_l/arrow").gameObject;
			brl=transform.Find("postion").gameObject;
			brl.transform.LookAt (destination);
			GameObject arrow = Instantiate (Resources.Load ("arrow")as GameObject) as GameObject;
			arrow.transform.position = brl.transform.position;
			arrow.GetComponent<ProjectileLauncher1> ().ThrowBallAtTargetLocation (destination,velocity);
		} else if (projectileName == "barrel") {
			brl = gameObject.transform.Find ("position").gameObject;
			GameObject barrel=Instantiate(Resources.Load("barrel")as GameObject) as GameObject;
			barrel.transform.position = brl.transform.position;
			barrel.GetComponent<Rigidbody> ().AddForce (barrel.transform.forward * velocity);
		}
		if (projectileName == "bomb 1") {
            brl = transform.Find("projectile position").gameObject;
			brl.transform.LookAt (destination);
			GameObject bomb = Instantiate (Resources.Load (projectileName) as GameObject) as GameObject;
			bomb.transform.position = brl.transform.position;
			bomb.GetComponent<Rigidbody> ().velocity = brl.transform.forward*velocity;
			GameObject effect = Instantiate (Resources.Load ("FireMobile") as GameObject) as GameObject;
			clip = Resources.Load ("fireSound") as AudioClip;
			player = gameObject.transform.GetComponent<AudioSource> ();
			player.clip = clip;
			effect.transform.position = brl.transform.position;
			player.Play ();
			Destroy (effect, 1);
		}

	}
	private void LookTowardEnmy(){
		if ( destination != Vector3.zero){
			Quaternion newRotation = Quaternion.LookRotation (destination - transform.position); //, Vector3.forward);
			newRotation.x = 0f;
			newRotation.z = 0f;
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.fixedDeltaTime = 10);
		}

	}
	private GameObject GetNearestEnmyPosition(){

		GameObject position=enemies[0].gameObject;
		Debug.Log (position.tag);
		float distanceFromEnmy =10000f;
		float previousDistance = distanceFromEnmy;
		foreach (Collider enmy in enemies) {
			if (enmy.tag == "Player") {	
				distanceFromEnmy = Vector3.Distance (transform.position, enmy.transform.position);
				if (distanceFromEnmy < previousDistance) {
					position = enmy.gameObject;
					Debug.Log ("Detected enmy tag is " + enmy.tag);
				}
				
			}
		}
		return position;
	}
	private bool IsThereEnmyAround(Vector3 spherePosition){
		int layer = LayerMask.NameToLayer ("Enmy");
		enemies = Physics.OverlapSphere (spherePosition,sightRadious,1<<layer);
		Debug.Log (enemies.Length);
		return enemies.Length>0;
	}


}
		
