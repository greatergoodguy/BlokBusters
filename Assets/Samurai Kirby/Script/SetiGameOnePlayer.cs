using UnityEngine;
using System.Collections;

public class SetiGameOnePlayer : SetiGame_Base {

	public static SetiGameOnePlayer Instance = new SetiGameOnePlayer();

	protected override bool WinConditionPlayerOne() {
		return Input.GetKeyDown(KeyCode.Space);
	}

	protected override bool WinConditionPlayerTwo() {
		return false;
	}
}
