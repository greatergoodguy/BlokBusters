using UnityEngine;
using System.Collections;

public class SetiGameOnePlayer : SetiGame_Base {

	public static SetiGameOnePlayer Instance = new SetiGameOnePlayer();

	bool hasTimerActionStarted;
	float elapsedTime;
	float reactionTime = 3.0f;

	public override void Enter() {
		base.Enter();

		hasTimerActionStarted = false;
		elapsedTime = 0;

		uiTimerAction.actionOnStart += () => {
			hasTimerActionStarted = true;
		};
	}

	public override void Update() {
		base.Update();

		if (!hasTimerActionStarted) {
			return;
		}

		elapsedTime += Time.deltaTime;
	}

	protected override bool WinConditionPlayerOne() {
		return Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space);
	}

	protected override bool WinConditionPlayerTwo() {
		return hasTimerActionStarted && elapsedTime > reactionTime;
	}

	public void SetAIReactionTime(float reactionTime) {
		this.reactionTime = reactionTime;
	}
}
