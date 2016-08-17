﻿using UnityEngine;
using System.Collections;

public class SetiGameTwoPlayers : SetiGame_Base {

	public static SetiGameTwoPlayers Instance = new SetiGameTwoPlayers();

	protected override bool WinConditionPlayerOne() {
		return Input.GetKeyDown(KeyCode.LeftShift);
	}

	protected override bool WinConditionPlayerTwo() {
		return Input.GetKeyDown(KeyCode.RightShift);
	}
}