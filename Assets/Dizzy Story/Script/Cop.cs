using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cop : MonoBehaviour {

	GameObject goSpeechBubble;
	bool isDialogueHappening = false;

	void CreateSpeechBubble(string dialogue) {
		Destroy(goSpeechBubble);

		Object oSpeechBubble = Resources.Load("Speech Bubble", typeof(GameObject));
		goSpeechBubble = GameObject.Instantiate(oSpeechBubble) as GameObject;
		goSpeechBubble.transform.position = transform.position + new Vector3(0, 5.5f, 0);

		Text text = goSpeechBubble.transform.Find("Canvas/Text").GetComponent<Text>();
		text.text = dialogue;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (isDialogueHappening) {
			return;
		}

		if (other.tag == "Dizzy") {
			StartCoroutine(DialogueDizzy());
		}
		if (other.tag == "Dizzy Black") {
			StartCoroutine(DialogueDizzyBlack());
		}
	}

	IEnumerator DialogueDizzy() {
		isDialogueHappening = true;
		CreateSpeechBubble("Hello Mr. Dizzy");
		yield return new WaitForSeconds(2);
		Destroy(goSpeechBubble);
		isDialogueHappening = false;
	}

	IEnumerator DialogueDizzyBlack() {
		isDialogueHappening = true;
		CreateSpeechBubble("Stop Thief");
		yield return new WaitForSeconds(2);
		transform.Find("Gun").gameObject.SetActive(true);
		CreateSpeechBubble("Pew Pew Pew");
		yield return new WaitForSeconds(2);
		CreateSpeechBubble("Get on the ground");
		yield return new WaitForSeconds(2);
		Destroy(goSpeechBubble);
		isDialogueHappening = false;
		Application.LoadLevel("Level 4 Black Eggs Matter");
	}
}
