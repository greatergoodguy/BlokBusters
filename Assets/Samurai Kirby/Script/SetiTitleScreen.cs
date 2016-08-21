﻿using UnityEngine;
using System.Collections;

public class SetiTitleScreen : SeTi_Base {

	public static SetiTitleScreen Instance = new SetiTitleScreen();

	ActorTitleScreen titleScreen;

	bool isFinished;
	bool isOnePlayerPressed = true;

	public override void Enter () {
		titleScreen = ActorTitleScreen.Instance;
		isFinished = false;

		titleScreen.Show();
		titleScreen.actionOnePlayer += () => {
			ActorSFX.Instance.Play(0);
			isFinished = true;
			isOnePlayerPressed = true;
		};

		titleScreen.actionTwoPlayers += () => {
			ActorSFX.Instance.Play(0);
			isFinished = true;
			isOnePlayerPressed = false;
		};

		titleScreen.actionNumMatches += () => {
			ActorSFX.Instance.Play(0);
		};
	}

	public override void Exit() {
		titleScreen.Hide();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason () {
//		if (isOnePlayerPressed) {
//			SetiGameOnePlayerMatches.Instance.Reset(titleScreen.NumMatches);
//			return SetiGameOnePlayerMatches.Instance;
//		} else {
//			SetiGameTwoPlayersMatches.Instance.Reset(titleScreen.NumMatches);
//			return SetiGameTwoPlayersMatches.Instance;
//		}

		if (isOnePlayerPressed) {
			SetiGameOnePlayerMatches.Instance.Reset(titleScreen.NumMatches);
			SetiGameFaceOff.Instance.Init(SetiGameOnePlayerMatches.Instance);

			return SetiGameFaceOff.Instance;
		} else {
			SetiGameTwoPlayersMatches.Instance.Reset(titleScreen.NumMatches);
			SetiGameFaceOff.Instance.Init(SetiGameTwoPlayersMatches.Instance);

			return SetiGameFaceOff.Instance;
		}
	}
}
