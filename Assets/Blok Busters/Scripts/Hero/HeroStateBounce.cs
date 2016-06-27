using UnityEngine;
using System.Collections;

public class HeroStateBounce : HeroState_Base {
	
	[SerializeField] private float bounceForce = 2000f;

	Vector2 bounceAngle = Vector2.up;

	public void SetBounceAngle(Vector2 bounceAngleNew) {
		bounceAngle = bounceAngleNew;
		//Toolbox.Log("bounceAngle - " + bounceAngle);
	}

	public override void Enter(Hero hero) {
		base.Enter(hero);
		//Toolbox.Log("bounceForce * bounceAngle - " + bounceForce * bounceAngle);
		Hero.Rigidbody2D.AddForce(bounceForce * bounceAngle);
	}

	public override bool IsFinished() {
		return true;
	}

	public override HeroState_Base GetNextState() {
		return Hero.stateMove;
	}
}
