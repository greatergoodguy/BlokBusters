﻿using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayButtonPressed() {
		Toolbox.Log("OnPlayButtonPressed()");
		Application.LoadLevel("Level 1");
	}
}
