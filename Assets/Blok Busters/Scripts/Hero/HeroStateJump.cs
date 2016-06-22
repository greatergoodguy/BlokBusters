using UnityEngine;
using System.Collections;

public class HeroStateJump : HeroState_Base {

	[SerializeField] private float jumpForce = 1000f;

	public override void Enter(Hero hero) {
		base.Enter(hero);
		Hero.Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
	}

	public override bool IsFinished() {
		return true;
	}

	public override HeroState_Base GetNextState() {
		return Hero.stateMove;
	}
}
