using UnityEngine;
using System.Collections;

public class SetiOnePlayer : SeTi_Base {

	public static SetiOnePlayer Instance = new SetiOnePlayer();

	ActorGameContainer gameContainer;

	GameUITimerAnticipation uiTimerAnticipation;
	GameUITimerAction uiTimerAction;
	GameUIExclamation uiExclamation;

	ActorGame game;

	bool hasGameOverCoroutineStarted = false;
	bool isFinished = false;

	public override void Enter () {
		ActorGame.Instance.Reset();

		gameContainer = ActorGameContainer.Instance;
		gameContainer.Show();

		uiTimerAnticipation = gameContainer.GetComponentInChildren<GameUITimerAnticipation>();
		uiTimerAction = gameContainer.GetComponentInChildren<GameUITimerAction>();
		uiExclamation = gameContainer.GetComponentInChildren<GameUIExclamation>();
		game = gameContainer.GetComponentInChildren<ActorGame>();

		Reset();
	}

	public override void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset();
		}

		if (hasGameOverCoroutineStarted) {
			return;
		}
			
		if(!uiTimerAnticipation.IsFinished && Input.GetKeyDown(KeyCode.Space)) {
			OnLose();
		}
		if(uiTimerAnticipation.IsFinished && Input.GetKeyDown(KeyCode.Space)) {
			OnWin();
		}
	}

	private void OnLose() {
		ActorSFX.Instance.Play(2);
		uiTimerAnticipation.Pause();
		uiExclamation.Hide();
		game.OnLose();
		ActorMasterMono.Instance.StartCoroutine(CoroutineGameOver(3));
	}

	private void OnWin() {
		ActorSFX.Instance.Play(1);
		uiTimerAction.Pause();
		uiExclamation.Hide();
		game.OnWin();
		ActorMasterMono.Instance.StartCoroutine(CoroutineGameOver(3));
	}

	IEnumerator CoroutineGameOver(float waitTime) {
		hasGameOverCoroutineStarted = true;
		yield return new WaitForSeconds(waitTime);
		Toolbox.Log("WaitAndPrint " + Time.time);
		hasGameOverCoroutineStarted = false;

		isFinished = true;
	}

	public override void Exit() {
		gameContainer.Hide();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason () {
		//return SeTiMock.Instance;
		return SetiTitleScreen.Instance;
	}

	void Reset() {
		hasGameOverCoroutineStarted = false;
		isFinished = false;

		uiTimerAnticipation.Reset(); 
		uiTimerAction.Reset();
		uiExclamation.Hide();

		game.Reset();

		uiTimerAnticipation.Begin();
		uiTimerAnticipation.actionTimerFinished += () => {
			ActorSFX.Instance.Play(3);
			uiExclamation.Show();
			uiTimerAction.Begin();
		};

		uiTimerAction.actionOnFinished += () => {
			OnLose();
		};

		ActorMasterMono.Instance.StopAllCoroutines();
	}
}
