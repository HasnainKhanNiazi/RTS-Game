using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBarrel : MonoBehaviour
{

	// Use this for initialization
	bool hit = false;
	GameObject explosion;
	public string pName;

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col)
	{
		
	   //if exploding projectile is a bomb
		if (tag == "bomb") {
			//render explosion effect
			explosion = Instantiate (Resources.Load ("explosion") as GameObject) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			explosion.GetComponent<Detonator> ().Explode ();
			Destroy (explosion, 5);
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			//get who was near explosion point
			Collider[] people = Physics.OverlapSphere (transform.position, 20);
			//Decrease health of each object under explosion
			foreach (Collider c in people) {
				if (c.tag == "Player") {
					c.gameObject.GetComponentInParent<Health> ().decreaseHealth (5 * Vector3.Distance (gameObject.transform.position, c.transform.position));
				}

			}
			Destroy (gameObject);
			// disable rendering of exploding object
			//GetComponent<MeshRenderer> ().enabled = false;
		}
		else if(tag=="arrow"){
			// if arrow hits body than decrease health of coresponding person
			if (col.transform.tag == "Player") {
				col.transform.GetComponent<Health> ().decreaseHealth (10);
			}
		}
		else if(tag=="barrel"){
			if (col.transform.tag == "Floor") {
				Debug.Log ("in barrel Section explosion");
				GameObject fireEffect = Resources.Load ("FireEffect") as GameObject;
				GameObject fire = Instantiate (fireEffect) as GameObject;
				fire.transform.position = transform.position;

				Collider[] people = Physics.OverlapSphere (transform.position, 20);
				//Decrease health of each object under explosion
				foreach (Collider c in people) {
					if (c.tag == "Player") {
						c.GetComponentInParent<Health> ().decreaseHealth (3 * Vector3.Distance (gameObject.transform.position, c.transform.position));
					}
					Destroy (fire, 5);
					//gameObject.GetComponent<MeshRenderer> ().enabled = false;
				}
				Destroy (transform.gameObject);

			}
	}
}

}
