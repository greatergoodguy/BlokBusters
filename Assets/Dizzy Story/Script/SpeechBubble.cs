using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechBubble : MonoBehaviour {

	public string dialogue;

	GameObject goSpeechBubble;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Dizzy") {
			Object oSpeechBubble = Resources.Load("Speech Bubble", typeof(GameObject));
			goSpeechBubble = GameObject.Instantiate(oSpeechBubble) as GameObject;
			goSpeechBubble.transform.position = transform.position + new Vector3(0, 5.5f, 0);

			Text text = goSpeechBubble.transform.Find("Canvas/Text").GetComponent<Text>();
			text.text = dialogue;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Dizzy") {
			Destroy(goSpeechBubble);
		}
	}
}
