using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TimerApna : MonoBehaviour{
    private float Timertext;
    public Text timer_text;
    NetworkManager nm = new NetworkManager();
	// Use this for initialization
	void Start () {
        Timertext = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - Timertext;
        string minutes = ((int) t/60).ToString();
        string seconds = (t % 60).ToString("f0");
        timer_text.text = minutes + ":" + seconds;

	}
}