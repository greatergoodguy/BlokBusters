using UnityEngine;
using System.Collections;

public class SetiResultsScreen : SeTi_Base {

	bool isFinished;

	float bestTime;
	int winsP1;
	int winsP2;

	public SetiResultsScreen(float bestTime, int winsP1, int winsP2) {
		this.bestTime = bestTime;
		this.winsP1 = winsP1;
		this.winsP2 = winsP2;
	}

	public override void Enter() {
		base.Enter();

		isFinished = false;

		ActorResultsScreen resultsScreen = ActorResultsScreen.Instance;
		resultsScreen.SetResults(bestTime, winsP1, winsP2);
		resultsScreen.Show();
		resultsScreen.actionDone += () => {
			isFinished = true;
		};
	}

	public override void Exit() {
		ActorResultsScreen resultsScreen = ActorResultsScreen.Instance;
		resultsScreen.Hide();
	}

	public override bool IsFinished() {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason() {
		return SetiTitleScreen.Instance;
	}


}
