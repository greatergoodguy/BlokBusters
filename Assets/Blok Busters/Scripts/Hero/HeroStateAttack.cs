using UnityEngine;
using System.Collections;

public class HeroStateAttack : HeroState_Base {

	[SerializeField] private float jumpForce = 1000f;

	private Transform tPosProjectLaunch;

	public override void Enter(Hero.Assistant assistant) {
		base.Enter(assistant);
		tPosProjectLaunch = Assistant.Transform.Find("Pos Projectile Launch");
		FireBoomBubble();
	}

	public override bool IsFinished() {
		return true;
	}

	public override HeroState_Base GetNextState() {
		return Assistant.Hero.stateMove;
	}

	public void FireBoomBubble() {
		GameObject goBoomBubble = Toolbox.Create("Projectile Boom Bubble");

		goBoomBubble.AddComponent<GeneSuicide>();

		GeneVelocity geneVelocity = goBoomBubble.AddComponent<GeneVelocity>();
		float speedX = 12;
		float velocityX = Assistant.IsFacingRight ? speedX : speedX * -1;
		geneVelocity.SetVelocity(velocityX, 0);

		Vector3 vLocalScaleBoomBubble = goBoomBubble.transform.localScale;
		if(!Assistant.IsFacingRight) { vLocalScaleBoomBubble *= -1;}
		goBoomBubble.transform.localScale = vLocalScaleBoomBubble;

		goBoomBubble.SetPos(tPosProjectLaunch);
	}
}
