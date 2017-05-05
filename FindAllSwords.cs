using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAllSwords : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GameObject.Find("Fight1").transform.FindChild("SelectionCircle").gameObject.SetActive(true);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void findswords()
    {
        GameObject.Find("Fight1").transform.FindChild("SelectionCircle").gameObject.SetActive(true);	
    }
}
