using UnityEngine;
using System.Collections;

public class GeneSpeechBubbleDizzy : MonoBehaviour {

	public string text;
	public int fontSize = 20;

	static GameObject goSpeechBubble;

	void Awake() {
	}

	void OnTriggerEnter2D(Collider2D other) {
//		Destroy(goSpeechBubble);
		if (goSpeechBubble != null) {
			return;
		}

		if (other.tag == "Dizzy") {
			if (text == null) {
				text = "";
			}

			goSpeechBubble = Factory.CreateSpeechBubble(text);
			goSpeechBubble.transform.position = Dizzy.Instance.transform.position + new Vector3(0, 5.5f, 0);
			goSpeechBubble.AddComponent<GeneSuicide>();
			GeneFollowObject geneFollowObject = goSpeechBubble.AddComponent<GeneFollowObject>();
			geneFollowObject.target = Dizzy.Instance.gameObject;
		}
	}
}
