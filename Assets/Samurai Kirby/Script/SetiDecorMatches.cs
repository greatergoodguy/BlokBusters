using UnityEngine;
using System.Collections;

public class SetiDecorMatches : SeTi_Base {

	SetiGame_Base setiGame;

	int matchesTotal;
	int matchesPlayed;

	public SetiDecorMatches(SetiGame_Base setiGame,int matchesTotal) {
		this.setiGame = setiGame;
		this.matchesTotal = matchesTotal;
		matchesPlayed = 0;
	}

	public override void Enter() {
		setiGame.Enter();

		matchesPlayed++;

		GameUI gameUI = ActorGameContainer.Instance.GetComponentInChildren<GameUI>();
		if (matchesTotal == 1) {
			Toolbox.Log("if (matchesTotal == 1)");
			gameUI.HideText();
		} else {
			Toolbox.Log("else");
			gameUI.SetText("Round " + matchesPlayed + " of " + matchesTotal);
			gameUI.ShowText();
		}
	}

	public override void Update() {
		setiGame.Update();
	}

	public override void Exit() {
		GameUI gameUI = ActorGameContainer.Instance.GetComponentInChildren<GameUI>();
		gameUI.HideText();

		setiGame.Exit();
	}

	public override bool IsFinished() {
		return setiGame.IsFinished();
	}

	public void Init(int matchesTotal) {
		this.matchesTotal = matchesTotal;
		matchesPlayed = 0;
	}

	public override SeTi_Base GetNextSeason() {
		if (matchesPlayed < matchesTotal) { 
			return this;} 
		else { 
			return SetiTitleScreen.Instance;}
	}
}
