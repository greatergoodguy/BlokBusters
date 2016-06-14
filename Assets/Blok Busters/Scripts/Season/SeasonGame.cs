using UnityEngine;
using System.Collections;

public class SeasonGame : Season_Base {

	private static SeasonGame instance;
	private SeasonGame() {}
	public static SeasonGame Instance {
		get 
		{
			if (instance == null) {
				instance = new SeasonGame();}

			return instance;
		}
	}

	public override void Enter() {}

	public override void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			HeroCharacter.Instance.SetPos(0, 0, 0);
		}
	}

	public override void Exit() {}

	public override bool IsFinished() {
		return false;
	}

	public override Season_Base GetNextSeason() {
		return SeasonMock.Instance;
	}
}