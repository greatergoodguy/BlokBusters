using UnityEngine;
using System;
using System.Collections;

public class GeneSpeech : MonoBehaviour {
	
	public string text;
	public int fontSize = 20;
	public Vector3 offset;

	GameObject goSpeechBubble;

	void Awake() {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Dizzy") {
			if (text == null) {
				text = "";
			}

			goSpeechBubble = Factory.CreateSpeechBubble(text);
			goSpeechBubble.transform.position = transform.position + offset;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Dizzy") {
			Destroy(goSpeechBubble);
		}
	}
}