using UnityEngine;
using System.Collections;

public class HeroStateBounce : HeroState_Base {
	
	[SerializeField] private float bounceForce = 1500f;

	public override void Enter(Hero hero) {
		base.Enter(hero);
		Hero.Rigidbody2D.velocity = Vector2.zero;
		Hero.Rigidbody2D.AddForce(new Vector2(0f, bounceForce));
	}

	public override bool IsFinished() {
		return true;
	}

	public override HeroState_Base GetNextState() {
		return Hero.stateMove;
	}
}
