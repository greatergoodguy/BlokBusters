using UnityEngine;
using System;
using System.Collections;

public class ActorTitleScreen : MonoBehaviour {

	public static ActorTitleScreen Instance;

	GameObject goPanel;

	public event Action actionOnePlayer = () => {};
	public event Action actionTwoPlayer = () => {};

	void Awake() {
		Instance = this;
		goPanel = transform.Find("Panel").gameObject;
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

	public void ButtonTwoPlayer() {
		actionTwoPlayer.Invoke();
	}
}
