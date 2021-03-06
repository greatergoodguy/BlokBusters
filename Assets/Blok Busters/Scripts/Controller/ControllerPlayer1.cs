﻿using UnityEngine;
using System.Collections;

public class ControllerPlayer1 : Controller_Base{
	public override bool IsKeyDownJump() {
		return Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Joystick1Button16) || Input.GetKeyDown(KeyCode.Space);
	}

	public override bool IsKeyDownAttack() {
		return Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button18);
	}

	public override float GetAxisHorizontal() {
		float axis = Input.GetAxis("Horizontal P1");
		if (Toolbox.NearlyEqual(axis, 0, 0.5f)) {
			return 0;
		}
		return axis;
	}
}
