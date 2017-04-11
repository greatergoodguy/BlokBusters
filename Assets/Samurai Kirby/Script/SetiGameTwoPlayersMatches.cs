using UnityEngine;
using System.Collections;

public class SetiGameTwoPlayersMatches : SetiGameTwoPlayers {

	public static SetiGameTwoPlayersMatches Instance = new SetiGameTwoPlayersMatches();

	int matchesTotal;
	int matchesPlayed;

	public override void Enter() {
		base.Enter();
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

	public override void Exit() {
		GameUI gameUI = ActorGameContainer.Instance.GetComponentInChildren<GameUI>();
		gameUI.HideText();
		base.Exit();
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
