using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlapshaerecheck : MonoBehaviour {

    public Collider[] hitColliders;
    public float Radius = 0f;
    public LayerMask mask;

	// Update is called once per frame
	void Update () {
        hitColliders = Physics.OverlapSphere(transform.position,Radius,mask);

        foreach (Collider col in hitColliders)
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

	}
}
