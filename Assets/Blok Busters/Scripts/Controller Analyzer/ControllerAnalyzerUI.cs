using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ControllerAnalyzerUI : MonoBehaviour {

	Text uiText;

	// Use this for initialization
	void Start () {
		uiText = gameObject.GetComponentInChildren<Text>();
	}

	// Update is called once per frame
	void Update () {
		String uiString = "";

		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
			if (Input.GetKeyDown(kcode)) {
				uiString += "KeyCode down: " + kcode + "\n";
				uiText.text = uiString;
			}
		}
	}
}
