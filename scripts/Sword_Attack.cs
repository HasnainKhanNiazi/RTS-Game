using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Attack : MonoBehaviour {

    void onTriggerEnter(Collision col)
    {
        Destroy(col.gameObject);
        print("Hello "+col.gameObject.name);
    }
}