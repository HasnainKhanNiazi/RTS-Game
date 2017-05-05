using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderDetection : MonoBehaviour {
	//public Slider health;
	public int health=100;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = this.transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator playy()
    {
        anim.Play("Death");
        yield return new WaitForSeconds(3);
    }

	void OnCollisionEnter(Collision c){
	
		if ((this.tag =="Ally" && c.collider.tag.Equals("SwordE")) ||(this.tag =="Enemy" && c.collider.tag.Equals("SwordA")) ) {
            health -= 10;
			Debug.Log ("health " + health +" of player "+ this.tag);
		}
		if (health <= 0) {
            playy();
			Destroy (this.transform.parent.gameObject);
		}
	}

}
