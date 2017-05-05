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
            GetComponent<unit2>().enabled = true;
        }
	}
}