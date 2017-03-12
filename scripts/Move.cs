using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Move : NetworkBehaviour {
	// Use this for initialization
    float speed = 10f;
    void Start()
    {
        //if (!isLocalPlayer)
        //{
        //    Destroy(this);
        //    return;
        //}
        //transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -1, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 1, 0);
    }
}