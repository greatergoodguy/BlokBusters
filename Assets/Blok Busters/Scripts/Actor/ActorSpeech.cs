using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActorSpeech : MonoBehaviour {
	
	Text textUI2D;

	void Awake() {
		textUI2D = transform.FindChild("Canvas/Text").GetComponent<Text>();
	}

	public void SetText(string text) {
		textUI2D.text = text;
	}

	public void SetFontSize(int fontSize) {
		textUI2D.fontSize = fontSize;
	}
}
