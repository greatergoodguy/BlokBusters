using UnityEngine;
using System.Collections;

public abstract class SetiGame_Base : SeTi_Base {

	ActorGameContainer gameContainer;

	public bool DidWinP1 { get; private set; }
	public bool DidWinP2 { get; private set; }
	public bool IsPrematureWin { get; private set; }

	protected GameUITimerAnticipation uiTimerAnticipation;
	protected GameUITimerAction uiTimerAction;
	private  GameUIExclamation uiExclamation;

	ActorGame game;

	bool hasGameOverCoroutineStarted = false;
	bool isFinished = false;

	public float getTime() {
		return uiTimerAction.GetAgeAction();
	}

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

		if(!uiTimerAnticipation.IsFinished && WinConditionPlayerOne()) {
			IsPrematureWin = true;
			OnWinPlayerTwo();
			game.OnWinPlayerTwoByPremature();
		}
		if(!uiTimerAnticipation.IsFinished && WinConditionPlayerTwo()) {
			OnWinPlayerOne();
			game.OnWinPlayerOneByPremature();
		}
		if(uiTimerAnticipation.IsFinished && WinConditionPlayerOne()) {
			OnWinPlayerOne();
			game.OnWinPlayerOne();
		}
		if(uiTimerAnticipation.IsFinished && WinConditionPlayerTwo()) {
			OnWinPlayerTwo();
			game.OnWinPlayerTwo();
		}
	}

	protected abstract bool WinConditionPlayerOne();
	protected abstract bool WinConditionPlayerTwo();

	private void OnWinPlayerTwo() {
		DidWinP2 = true;
		ActorSFX.Instance.Stop(4);
		ActorSFX.Instance.Play(2);
		uiTimerAnticipation.Pause();
		uiTimerAction.Pause();
		uiExclamation.Hide();
		ActorMasterMono.Instance.StartCoroutine(CoroutineGameOver(3));
	}

	private void OnWinPlayerOne() {
		DidWinP1 = true;
		ActorSFX.Instance.Stop(4);
		ActorSFX.Instance.Play(1);
		uiTimerAnticipation.Pause();
		uiTimerAction.Pause();
		uiExclamation.Hide();
		ActorMasterMono.Instance.StartCoroutine(CoroutineGameOver(3));
	}

	private void OnWinNoone() {
		ActorSFX.Instance.Stop(4);
		ActorSFX.Instance.Play(6);
		uiTimerAnticipation.Pause();
		uiTimerAction.Pause();
		uiExclamation.Hide();
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
		ActorSFX.Instance.Stop(4);
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
		ActorMasterMono.Instance.StopAllCoroutines();

		DidWinP1 = false;
		DidWinP2 = false;
		IsPrematureWin = false;

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
			OnWinNoone();
			game.OnWinNoone();
		};

		ActorSFX.Instance.Stop(4);
		ActorSFX.Instance.Play(4);
	}
}
