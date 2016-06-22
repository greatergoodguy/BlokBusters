using UnityEngine;
using System.Collections;

public class HeroStateAttack : HeroState_Base {

	[SerializeField] private float jumpForce = 1000f;

	private Transform tPosProjectLaunch;

	public override void Enter(Hero hero) {
		base.Enter(hero);
		tPosProjectLaunch = Hero.Transform.Find("Pos Projectile Launch");
		FireBoomBubble();
	}

	public override bool IsFinished() {
		return true;
	}

	public override HeroState_Base GetNextState() {
		return Hero.stateMove;
	}

	public void FireBoomBubble() {
		GameObject goBoomBubble = Toolbox.Create("Projectile Boom Bubble");

		goBoomBubble.AddComponent<GeneSuicide>();

		GeneVelocity geneVelocity = goBoomBubble.AddComponent<GeneVelocity>();
		float speedX = 24;
		float velocityX = Hero.IsFacingRight ? speedX : speedX * -1;
		geneVelocity.SetVelocity(velocityX, 0);

		Vector3 vLocalScaleBoomBubble = goBoomBubble.transform.localScale;
		if(!Hero.IsFacingRight) { vLocalScaleBoomBubble *= -1;}
		goBoomBubble.transform.localScale = vLocalScaleBoomBubble;

		goBoomBubble.SetPos(tPosProjectLaunch);
	}
}
