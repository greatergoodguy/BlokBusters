using UnityEngine;
using System.Collections;

public class SetiBigBang : SeTi_Base {

	public static SetiBigBang Instance = new SetiBigBang();

	ActorTitleScreen 	titleScreen;
	ActorGameContainer	gameContainer;

	public override void Enter () {
		titleScreen = ActorTitleScreen.Instance;
		gameContainer = ActorGameContainer.Instance;
	}

	public override void Exit() {
		titleScreen.Hide();
		gameContainer.Hide();
	}

	public override bool IsFinished () {
		return true;
	}

	public override SeTi_Base GetNextSeason () {
		return SetiTitleScreen.Instance;
		//return SetiGameOnePlayer_Dep.Instance;
	}
}
