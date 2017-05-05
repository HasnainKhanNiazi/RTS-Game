using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour {
    Animator anim;

	// Use this for initialization
	public float health=100;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator waitfordeathAnimation(int seconds)
    {
		GetComponent<unit2> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = false;
        anim.Play("Death");
        yield return new WaitForSeconds(seconds);
        Destroy(this.transform.gameObject);
    }


	public void decreaseHealth(float num){
		if (health > 0) {
			health -= num;
		}

        if (health <= 0)
        {
            StartCoroutine(waitfordeathAnimation(4));  
        }
		Debug.Log (health + "  after" + (health - num));
	}
}
