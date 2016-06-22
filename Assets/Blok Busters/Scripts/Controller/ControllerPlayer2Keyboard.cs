using UnityEngine;
using System.Collections;

public class ControllerPlayer2Keyboard : Controller_Base {
	public override bool IsKeyDownJump() {
		return Input.GetKeyDown(KeyCode.Slash) || Input.GetKeyDown(KeyCode.Joystick2Button16);
	}

	public override bool IsKeyDownAttack() {
		return Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Joystick2Button18);
	}

	public override float GetAxisHorizontal() {
		float axis = Input.GetAxis("Horizontal P2 Keyboard");
		return axis;
	}
}
