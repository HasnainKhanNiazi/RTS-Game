﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {
    public Transform Loadingbar;
    public Transform TextIndicator;
    public Transform TextLoading;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;

	// Update is called once per frame
	void Update () {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            TextLoading.gameObject.SetActive(true);
        }
        else
        {
            TextLoading.gameObject.SetActive(false);
            TextIndicator.GetComponent<Text>().text = "Done!";
        }
        Loadingbar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
}
