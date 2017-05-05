using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawnPrefab : NetworkBehaviour
{
    public GameObject SpawnObj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isServer)
            {
                CmdSpawnSwordServer();
            }
            else
            {
                CmdSpawnSwordClient();
            }
        }
    }

    [Command]
    void CmdSpawnSwordServer()
    {
        var Aiagent = (GameObject)GameObject.Instantiate(SpawnObj, SpawnObj.transform.position, SpawnObj.transform.rotation);
        NetworkServer.Spawn(Aiagent);
    }

    [Command]
    void CmdSpawnSwordClient()
    {
        GameObject troop = Instantiate(SpawnObj, transform.position, Quaternion.identity) as GameObject;
        troop.transform.tag = tag;
        troop.transform.FindChild("Hips").tag = tag;
        troop.transform.FindChild("Paladin_J_Nordstrom_Sword").tag = "SwordE";
        NetworkServer.SpawnWithClientAuthority(troop, gameObject);
    }
}