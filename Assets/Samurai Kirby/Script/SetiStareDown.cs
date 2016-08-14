using UnityEngine;
using System.Collections;

public class SetiStareDown : SeTi_Base {

	public static SetiBigBang Instance = new SetiBigBang();

	public override void Enter () {
		ActorGameContainer.Instance.Show();
	}

	public override bool IsFinished () {
		return false;
	}

	public override SeTi_Base GetNextSeason () {
		return SetiOnePlayer.Instance;
	}
}
