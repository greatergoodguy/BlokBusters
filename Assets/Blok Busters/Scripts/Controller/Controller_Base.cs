using UnityEngine;
using System.Collections;

public abstract class Controller_Base {

	public abstract bool IsKeyDownJump();
	public abstract bool IsKeyDownAttack();
	public abstract float GetAxisHorizontal();
}
