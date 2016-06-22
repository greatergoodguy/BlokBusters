using UnityEngine;
using System.Collections;

public class HeroStateHurt : HeroState_Base {

	Sprite spriteHurt;
	Sprite spriteNormal;
	float elapsedTime;
	bool isFinished;

	public override void Enter(Hero hero) {
		base.Enter(hero);
		if (spriteHurt == null) { spriteHurt = Resources.Load<Sprite>("hero_hurt");}
		if (spriteNormal == null) { spriteNormal = Resources.Load<Sprite>("hero_normal");}

		elapsedTime = 0;
		isFinished = false;

		Hero.ChangeSprite(spriteHurt);

		if (Hero.IsFacingRight) {
			Hero.Rigidbody2D.velocity = Vector2.zero;
			Hero.Rigidbody2D.AddForce(new Vector2(-200f, 50f));
		} else {
			Hero.Rigidbody2D.velocity = Vector2.zero;
			Hero.Rigidbody2D.AddForce(new Vector2(200f, 50f));
		}
	}

	public override void Update() {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > 1.0f) {
			isFinished = true;
		}
	}

	public override void Exit() {
		Hero.ChangeSprite(spriteNormal);
	}

	public override bool IsFinished() {
		return isFinished;
	}

	public override HeroState_Base GetNextState() {
		return Hero.stateMove;
	}
}
