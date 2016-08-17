using UnityEngine;
using System.Collections;

public class SetiTitleScreen : SeTi_Base {

	public static SetiTitleScreen Instance = new SetiTitleScreen();

	ActorTitleScreen titleScreen;
	bool isFinished;

	public override void Enter () {
		titleScreen = ActorTitleScreen.Instance;
		isFinished = false;

		titleScreen.Show();
		titleScreen.actionOnePlayer += () => {
			ActorSFX.Instance.Play(0);
			isFinished = true;
		};

	}

	public override void Exit() {
		titleScreen.Hide();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason () {
		//return SetiStareDown.Instance;
		return SetiOnePlayer.Instance;
	}
}
