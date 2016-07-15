using UnityEngine;
using System;
using System.Collections;

public class GeneSpeech : MonoBehaviour {

	public static readonly string TAG = typeof(GeneSpeech).Name;

	public string text;
	public int fontSize = 20;

	//AISpeech aiSpeech;

	void Awake() {
	}

	void OnTriggerEnter(Collider other) {
		Toolbox.Log("OnTriggerEnter()");

		if(text == null) {
			text = "";}

//		aiSpeech = Factory.CreateSpeechBubble(text, transform);
//		aiSpeech.SetFontSize(fontSize);
	}

	void OnTriggerExit(Collider other) {
		Toolbox.Log("OnTriggerExit()");

//		if(aiSpeech == null) {return;}

//		Destroy(aiSpeech.gameObject);
	}
}