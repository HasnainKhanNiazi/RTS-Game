using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBarrel : MonoBehaviour {
	float timeCounter=0;
	public GameObject position=null;
	public float sightRadious;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCounter > 1) {
			timeCounter = -1;
			if (IsThereEnmyAround (position.transform.position)) {
				GameObject barrelPosition = gameObject.transform.Find ("position").gameObject;
				GameObject barrel = Instantiate (Resources.Load ("barrel")as GameObject) as GameObject;
				barrel.transform.position = barrelPosition.transform.position;
				barrel.GetComponent<Rigidbody> ().velocity = barrelPosition.transform.forward*5;
			}
		}
		timeCounter += Time.deltaTime;
	}
	private bool IsThereEnmyAround(Vector3 spherePosition){
		int layer = LayerMask.NameToLayer ("Enmy");
		int detect=Physics.OverlapSphere (spherePosition,sightRadious,1<<layer).Length;
		return detect>0;
	}
}
