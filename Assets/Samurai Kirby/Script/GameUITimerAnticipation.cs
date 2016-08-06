using UnityEngine;
using System;
using System.Collections;

public class GameUITimerAnticipation : MonoBehaviour {

	public bool IsPaused { get; private set; }
	public bool IsFinished { get; private set;}

	GameObject goTimer;
	float MAX_AGE = 2.4f;
	float age = 0;

	public event Action actionTimerFinished = () => {};

	void Awake() {
		goTimer = transform.Find("Panel/Anticipation Timer").gameObject;
		goTimer.Show();
	}

	void Start() {
		Reset();
	}

	// Update is called once per frame
	void Update () {
		if (IsPaused) {
			return;
		}

		if (IsFinished) {
			return;
		}

		if (age >= MAX_AGE) {
			actionTimerFinished.Invoke();
			IsFinished = true;
			return;
		}

		age += Time.deltaTime;
		//Toolbox.Log("age: " + age);

		float fraction = Mathf.Max((MAX_AGE - age) / MAX_AGE, 0);
		//Toolbox.Log("fraction: " + fraction);

		Vector3 localScaleTemp = goTimer.transform.localScale;
		localScaleTemp.x = fraction;
		goTimer.transform.localScale = localScaleTemp;
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
		age = 0;

		Vector3 localScaleTemp = goTimer.transform.localScale;
		localScaleTemp.x = 1;
		goTimer.transform.localScale = localScaleTemp;
	}
}
