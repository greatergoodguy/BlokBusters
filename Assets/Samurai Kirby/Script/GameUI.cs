using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour {

	Text text;

	void Awake() {
		text = transform.Find("Panel/Text").GetComponent<Text>();
	}
		
	void Start () {
		HideText();
	}

	public void SetText(string message) {
		text.text = message;
	}

	public void ShowText() {
		text.Show();
	}

	public void HideText() {
		text.Hide();
	}
	
}
