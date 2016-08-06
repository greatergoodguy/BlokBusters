using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUITimerAction : MonoBehaviour {

	public bool IsPaused { get; private set; }
	public bool IsFinished { get; private set;}

	Text textActionTimer;
	float MAX_AGE = 5.0f;
	float ageAction = 0;

	// Use this for initialization
	void Awake () {
		textActionTimer = transform.Find("Panel/Action Timer").GetComponent<Text>();
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
			return;
		}

		ageAction += Time.deltaTime;
		textActionTimer.text = ageAction.ToString();
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
		textActionTimer.text = ageAction.ToString();
	}
}
