using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameUITimerAnticipation : MonoBehaviour {

	public bool IsPaused { get; private set; }
	public bool IsFinished { get; private set;}

	GameObject goTimer;
	float MAX_AGE_MIN = 2.0f;
	float MAX_AGE_MAX = 8.0f;
	float maxAge = 0;
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
		if(Input.GetKeyDown(KeyCode.Q)) {
			Image iTimer = goTimer.GetComponent<Image>();
			iTimer.enabled = !iTimer.enabled;
		}

		if (IsPaused) {
			return;
		}

		if (IsFinished) {
			return;
		}

		if (age >= maxAge) {
			actionTimerFinished.Invoke();
			IsFinished = true;
			return;
		}

		age += Time.deltaTime;
		//Toolbox.Log("age: " + age);

		float fraction = Mathf.Max((maxAge - age) / maxAge, 0);
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
		maxAge = UnityEngine.Random.Range(MAX_AGE_MIN, MAX_AGE_MAX);

		IsFinished = true;
		IsPaused = false;
		age = 0;

		Vector3 localScaleTemp = goTimer.transform.localScale;
		localScaleTemp.x = 1;
		goTimer.transform.localScale = localScaleTemp;
	}
}
