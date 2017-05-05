using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour {

    bool pause = false;
    public GameObject Panel;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            if (pause)
            {
                Panel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Panel.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
	}
}