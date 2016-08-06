using UnityEngine;
using System.Collections;

public class SetiOnePlayer : SeTi_Base {

	public static SetiOnePlayer Instance = new SetiOnePlayer();

	GameUITimerAnticipation uiTimerAnticipation;
	GameUITimerAction uiTimerAction;
	GameUIExclamation uiExclamation;

	public override void Enter () {
		ActorGame.Instance.Reset();

		ActorGameContainer gameContainer = ActorGameContainer.Instance;
		gameContainer.Show();

		uiTimerAnticipation = gameContainer.GetComponentInChildren<GameUITimerAnticipation>();
		uiTimerAction = gameContainer.GetComponentInChildren<GameUITimerAction>();
		uiExclamation = gameContainer.GetComponentInChildren<GameUIExclamation>();

		Reset();
	}

	public override void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset();
		}

		if(!uiTimerAnticipation.IsFinished && Input.GetKeyDown(KeyCode.Space)) {
			uiTimerAnticipation.Pause();
		}
		if(uiTimerAnticipation.IsFinished && Input.GetKeyDown(KeyCode.Space)) {
			uiTimerAction.Pause();
		}
	}

	public override bool IsFinished () {
		return false;
	}

	public override SeTi_Base GetNextSeason () {
		return SeTiMock.Instance;
	}

	void Reset() {
		uiTimerAnticipation.Reset(); 
		uiTimerAction.Reset();
		uiExclamation.Hide();

		uiTimerAnticipation.Begin();
		uiTimerAnticipation.actionTimerFinished += () => {
			uiExclamation.Show();
			uiTimerAction.Begin();
		};
	}
}
