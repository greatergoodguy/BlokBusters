using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ActorTitleScreen : MonoBehaviour {

	public static ActorTitleScreen Instance;

	GameObject goPanel;

	public int NumMatches { get; private set; }

	public event Action actionOnePlayer = () => {};
	public event Action actionTwoPlayers = () => {};

	void Awake() {
		Instance = this;
		goPanel = transform.Find("Panel").gameObject;
		if (goPanel == null) {
			goPanel = new GameObject();
		}
	}

	public void Show() {
		goPanel.SetActive(true);
	}

	public void Hide() {
		goPanel.SetActive(false);
	}

	public void ButtonOnePlayer() {
		actionOnePlayer.Invoke();
	}

	public void ButtonTwoPlayers() {
		actionTwoPlayers.Invoke();
	}

	public void ButtonNumMatches(int numMatches) {
		NumMatches = numMatches;

		Text text = transform.Find("Panel/Panel Buttons/Matches Text").GetComponent<Text>();
		text.text = "Matches: " + NumMatches;
	}
}
