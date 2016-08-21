using UnityEngine;
using System.Collections;

public class SetiGameFaceOff : SeTi_Base {

	public static SetiGameFaceOff Instance = new SetiGameFaceOff();

	GameUIFader uiFader;

	public override void Enter() {
		ActorGameContainer gameContainer = ActorGameContainer.Instance;
		gameContainer.Show();

		uiFader = gameContainer.GetComponentInChildren<GameUIFader>();
	}

	public override void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			//uiFader.Fade();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			//uiFader.UnFade();
		}
	}
}
