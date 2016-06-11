using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class HeroStateMove : HeroState_Base {

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float jumpForce = 400f;

	private bool isFacingRight = true;

	public override void Enter(Hero.Assistant assistant) {
		base.Enter(assistant);
	}

	public override void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && Assistant.IsGrounded) {
			Assistant.Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			Toolbox.Log("jumpForce = " + jumpForce);
		}
	}

	public override void FixedUpdate() {
		float axisHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		Assistant.Rigidbody2D.velocity = new Vector2(axisHorizontal * maxSpeed, Assistant.Rigidbody2D.velocity.y);

		if (axisHorizontal > 0 && !isFacingRight) {
			Flip();
		}
		else if (axisHorizontal < 0 && isFacingRight) {			
			Flip();
		}
	}

	private void Flip() {
		isFacingRight = !isFacingRight;

		Vector3 localScale = Assistant.Transform.localScale;
		localScale.x *= -1;
		Assistant.Transform.localScale = localScale;
	}

	private static HeroStateMove instance;
	private HeroStateMove() {}
	public static HeroStateMove Instance {
		get {
			if (instance == null) {
				instance = new HeroStateMove();}

			return instance;
		}
	}
}
