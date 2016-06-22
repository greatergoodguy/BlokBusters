using UnityEngine;
using System.Collections;

public abstract class HeroState_Base {

	protected Hero Hero { get; private set; }

	public virtual void Enter(Hero hero) {
		this.Hero = hero;
	}
	public virtual void Update() {}
	public virtual void FixedUpdate() {}
	public virtual void Exit() {}

	public virtual bool IsFinished() { return false;}
	public virtual HeroState_Base GetNextState() { return HeroStateMock.Instance;}

}