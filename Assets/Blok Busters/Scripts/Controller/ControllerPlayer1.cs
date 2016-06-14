using UnityEngine;
using System.Collections;

public class ControllerPlayer1 : Controller_Base{
	public override bool IsKeyDownJump() {
		return Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Joystick1Button16);
	}

	public override bool IsKeyDownAttack() {
		return Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button18);
	}

	public override float GetAxisHorizontal() {
		return Input.GetAxis("Horizontal P1");
	}
}
