using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class Factory {

	static Object oCloneSpeechBubble;
	public static GameObject CreateSpeechBubble(string dialogue) {
		if (oCloneSpeechBubble == null) {
			oCloneSpeechBubble = Resources.Load("Speech Bubble", typeof(GameObject));
		}

		GameObject gameObject = GameObject.Instantiate(oCloneSpeechBubble) as GameObject;
		Text text = gameObject.transform.Find("Canvas/Text").GetComponent<Text>();
		text.text = dialogue;

		return gameObject;
	}

}
