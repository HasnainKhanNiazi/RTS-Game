using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetUpLocalPlayer : NetworkBehaviour {
    [SyncVar]
    public string Pname = "player";
    [SyncVar]
    public Color playercolor = Color.white;

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            GetComponent<unit>().enabled = true;
            Renderer[] rends = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rends)
                r.material.color = playercolor; 
        }
	}
    void Update()
    {

    }
}