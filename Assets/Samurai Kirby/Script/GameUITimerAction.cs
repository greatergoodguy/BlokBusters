using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameUITimerAction : MonoBehaviour {

	public bool IsPaused { get; private set; }
	public bool IsFinished { get; private set;}

	Text textActionTimer;
	float MAX_AGE = 1.5f;
	float ageAction = 0;

	public event Action actionOnFinished = () => {};

	void Awake () {
		textActionTimer = transform.Find("Panel/Action Timer").GetComponent<Text>();
		textActionTimer.Show();
	}

	void Start() {
		Reset();
	}

	void Update () {
		if (IsPaused) {
			return;
		}

		if (IsFinished) {
			return;
		}

		if (ageAction >= MAX_AGE) {
			ageAction = MAX_AGE;
			IsFinished = true;
			actionOnFinished.Invoke();
			return;
		}

		ageAction += Time.deltaTime;
		textActionTimer.text = ageAction.ToString("F2");
	}

	public void Begin() {
		IsFinished = false;
		IsPaused = false;
	}

	public void Pause() {
		IsPaused = true;
	}

	public void Resume() {
		IsPaused = false;
	}

	public void Reset() {
		IsFinished = true;
		IsPaused = false;
		ageAction = 0;
		textActionTimer.text = ageAction.ToString("F2");
	}
}
