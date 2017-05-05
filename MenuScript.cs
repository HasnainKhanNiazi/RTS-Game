using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Canvas quitmenu;
	public Button starttext;
	public Button exittext;
	void Start () {
		quitmenu = quitmenu.GetComponent<Canvas> ();
		starttext = starttext.GetComponent<Button> ();
		exittext = exittext.GetComponent<Button> ();
		quitmenu.enabled = false;
	}
//	public void Options(){
//	}

	public void ExitPress(){
		quitmenu.enabled = true;
		starttext.enabled = false;
		exittext.enabled = false;
	}
	public void Nopress(){
		quitmenu.enabled = false;
		starttext.enabled = true;
		exittext.enabled = true;
	}
	public void Exitgame(){
		Application.Quit ();
	}
}
