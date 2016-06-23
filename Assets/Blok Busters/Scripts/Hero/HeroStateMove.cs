using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class HeroStateMove : HeroState_Base {

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float additiveMovementForce = 30f;
	[SerializeField] private float jumpForce = 1000f;

	public override void Update() {
		if (Hero.Controller.IsKeyDownJump() && Hero.IsGrounded) {
			Hero.ChangeState(Hero.stateJump);
		}

		if (Hero.Controller.IsKeyDownAttack()) {
			Hero.ChangeState(Hero.stateAttack);
		}
			
		float axisHorizontal 		= Hero.Controller.GetAxisHorizontal();
		float velXCurrent 			= Hero.Rigidbody2D.velocity.x;
		float resistanceMultiplier 	= 3;

//		if (velXCurrent <= maxSpeed && velXCurrent >= -maxSpeed) {
//			Hero.Rigidbody2D.velocity = new Vector2(axisHorizontal * maxSpeed, Hero.Rigidbody2D.velocity.y);
//		}

		if (velXCurrent <= maxSpeed && velXCurrent >= -maxSpeed) {
			Hero.Rigidbody2D.AddForce(new Vector2(axisHorizontal * additiveMovementForce, 0));
		}

		Toolbox.Log("Hero.Rigidbody2D.velocity - " + Hero.Rigidbody2D.velocity);

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
