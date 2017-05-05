using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetUpLocalPLayerArrow : NetworkBehaviour {

    [SyncVar]
    public string Pname = "player";
    [SyncVar]
    public Color playercolor = Color.white;

    void Update()
    {
        if (isLocalPlayer)
        {
            GetComponent<Arrow_Script>().enabled = true;
        }
    }

}
