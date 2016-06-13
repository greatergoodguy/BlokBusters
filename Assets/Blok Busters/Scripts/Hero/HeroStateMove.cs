using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class HeroStateMove : HeroState_Base {

	[SerializeField] private float maxSpeed = 10f;
	[SerializeField] private float jumpForce = 400f;

	private bool isFacingRight = true;

	private Transform tPosProjectLaunch;

	public override void Enter(Hero.Assistant assistant) {
		base.Enter(assistant);

		tPosProjectLaunch = Assistant.Transform.Find("Pos Projectile Launch");
	}

	public override void Update() {
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button16)) && Assistant.IsGrounded) {
			Assistant.Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			Toolbox.Log("jumpForce = " + jumpForce);
		}

		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			FireBoomBubble();
		}
	}

	public void FireBoomBubble() {
		GameObject goBoomBubble = Toolbox.Create("Projectile Boom Bubble");

		goBoomBubble.AddComponent<GeneSuicide>();

		GeneVelocity geneVelocity = goBoomBubble.AddComponent<GeneVelocity>();
		float speedX = 12;
		float velocityX = isFacingRight ? speedX : speedX * -1;
		geneVelocity.SetVelocity(velocityX, 0);

		Vector3 vLocalScaleBoomBubble = goBoomBubble.transform.localScale;
		if(!isFacingRight) { vLocalScaleBoomBubble *= -1;}
		goBoomBubble.transform.localScale = vLocalScaleBoomBubble;

		goBoomBubble.SetPos(tPosProjectLaunch);
	}

	public override void FixedUpdate() {
		float axisHorizontal = Input.GetAxis("Horizontal");
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
