using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using System.Collections;

public class ActorGameUI : MonoBehaviour {

	GameObject goAnticipationTimer;
	float MAX_AGE = 2.4f;
	float age = 0;
	bool isAnticipationTimerFinished = false;

	Text textActionTimer;
	float ageAction = 0;

	bool isActionPressed = false;
	bool isActionPressedEarly = false;

	[Serializable] public class ButtonClickedEvent : UnityEvent {}
	[SerializeField] private ButtonClickedEvent onActionPressed = new ButtonClickedEvent();

	[SerializeField] private UnityEvent onActionPressedEarly = new UnityEvent();

	void Awake() {
		goAnticipationTimer = transform.Find("Panel/Anticipation Timer").gameObject;
		textActionTimer = transform.Find("Panel/Action Timer").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset();
		}

		if (isActionPressed || isActionPressedEarly) {
			return;
		}

		if (!isAnticipationTimerFinished) {
			UpdateTimerBar();
		} else {
			UpdateActionTimer();
		}
	}

	void Reset() {
		age = 0;
		isAnticipationTimerFinished = false;

		textActionTimer.text = "0.0";
		ageAction = 0;

		isActionPressed = false;
		isActionPressedEarly = false;
	}

	void UpdateActionTimer() {
		ageAction += Time.deltaTime;
		textActionTimer.text = ageAction.ToString();

		if (Input.GetKeyDown(KeyCode.Space)) {
			isActionPressed = true;
			onActionPressed.Invoke();
		}
	}

	void UpdateTimerBar() {
		if (age >= MAX_AGE) {
			isAnticipationTimerFinished = true;
			return;
		}

		age += Time.deltaTime;
		//Toolbox.Log("age: " + age);

		float fraction = Mathf.Max((MAX_AGE - age) / MAX_AGE, 0);
		//Toolbox.Log("fraction: " + fraction);

		Vector3 localScaleTemp = goAnticipationTimer.transform.localScale;
		localScaleTemp.x = fraction;
		goAnticipationTimer.transform.localScale = localScaleTemp;

		if (Input.GetKeyDown(KeyCode.Space)) {
			isActionPressedEarly = true;
			onActionPressedEarly.Invoke();
		}
	}
}
