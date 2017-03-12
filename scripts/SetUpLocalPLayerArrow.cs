using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetUpLocalPLayerArrow : NetworkBehaviour {

    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<unit>().enabled = true;
        }
    }
}
