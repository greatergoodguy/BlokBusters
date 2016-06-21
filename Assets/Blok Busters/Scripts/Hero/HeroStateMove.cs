using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class HeroStateMove : HeroState_Base {

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float jumpForce = 1000f;

	public override void Update() {
		if (Assistant.Controller.IsKeyDownJump() && Assistant.IsGrounded) {
			Assistant.ChangeState(Assistant.Hero.stateJump);
		}

		if (Assistant.Controller.IsKeyDownAttack()) {
			Assistant.ChangeState(Assistant.Hero.stateAttack);
		}


		float axisHorizontal = Assistant.Controller.GetAxisHorizontal();
		Assistant.Rigidbody2D.velocity = new Vector2(axisHorizontal * maxSpeed, Assistant.Rigidbody2D.velocity.y);
		//Toolbox.Log("Update() - axisHorizontal: " + axisHorizontal);
		if (axisHorizontal > 0 && !Assistant.IsFacingRight) {
			Flip();
		}
		else if (axisHorizontal < 0 && Assistant.IsFacingRight) {			
			Flip();
		}
	}
		
	private void Flip() {
		Assistant.IsFacingRight = !Assistant.IsFacingRight;

		Vector3 localScale = Assistant.Transform.localScale;
		localScale.x *= -1;
		Assistant.Transform.localScale = localScale;
	}
}
