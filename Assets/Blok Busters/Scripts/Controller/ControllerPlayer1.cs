using UnityEngine;
using System.Collections;

public static class ControllerPlayer1 {
	public static bool IsKeyDownReset() {
		return Input.GetKeyDown(KeyCode.R);
	}
}
