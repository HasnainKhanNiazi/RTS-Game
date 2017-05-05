using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSync : MonoBehaviour
{
    /// <summary>
    /// This script is attached to the player and it
    /// ensures that every players position, rotation, and scale,
    /// are kept up to date across the network.
    ///
    /// This script is closely based on a script written by M2H.
    /// </summary>
    NetworkView view;
    private Vector3 lastPosition;

    private Quaternion lastRotation;

    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        view = GetComponent<NetworkView>();
        if (view.isMine == true)
        {
            myTransform = transform;


            //Ensure taht everyone sees the player at the correct location
            //the moment they spawn.

            view.RPC("UpdateMovement", RPCMode.OthersBuffered, myTransform.position, myTransform.rotation);
        }
        else
        {
            enabled = false;
        }
    }


    void OnServerInitialized()
    {
        Debug.Log("Server initialized and ready");
    }

    // Update is called once per frame
    void Update()
    {
        //If the player has moved at all then fire off an RPC to update the players
        //position and rotation across the network.

        if (Vector3.Distance(myTransform.position, lastPosition) >= 0.1)
        {
            //Capture the player's position before the RPC is fired off and use this
            //to determine if the player has moved in the if statement above.

            lastPosition = myTransform.position;
            view.RPC("UpdateMovement", RPCMode.OthersBuffered, myTransform.position, myTransform.rotation);
        }

        if (Quaternion.Angle(myTransform.rotation, lastRotation) >= 1)
        {
            //Capture the player's rotation before the RPC is fired off and use this
            //to determine if the player has turned in the if statement above. 

            lastRotation = myTransform.rotation;
            view.RPC("UpdateMovement", RPCMode.Others, myTransform.position, myTransform.rotation);
        }
    }

    [RPC]
    void UpdateMovement(Vector3 newPosition, Quaternion newRotation)
    {
        Debug.Log("Moveddd");
        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}
