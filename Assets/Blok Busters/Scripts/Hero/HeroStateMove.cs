using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class HeroStateMove : HeroState_Base {

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float jumpForce = 1000f;

	public override void Update() {
		if (Hero.Controller.IsKeyDownJump() && Hero.IsGrounded) {
			Hero.ChangeState(Hero.stateJump);
		}

		if (Hero.Controller.IsKeyDownAttack()) {
			Hero.ChangeState(Hero.stateAttack);
		}


		float axisHorizontal = Hero.Controller.GetAxisHorizontal();
		Hero.Rigidbody2D.velocity = new Vector2(axisHorizontal * maxSpeed, Hero.Rigidbody2D.velocity.y);
		//Toolbox.Log("Update() - axisHorizontal: " + axisHorizontal);
		if (axisHorizontal > 0 && !Hero.IsFacingRight) {
			Flip();
		}
		else if (axisHorizontal < 0 && Hero.IsFacingRight) {			
			Flip();
		}
	}
		
	private void Flip() {
		Hero.IsFacingRight = !Hero.IsFacingRight;

		Vector3 localScale = Hero.Transform.localScale;
		localScale.x *= -1;
		Hero.Transform.localScale = localScale;
	}
}
