using UnityEngine;
using System.Collections;

public abstract class Season_Base {

	public abstract void Enter();
	public abstract void Exit();
	public abstract void Update();

	public abstract bool IsFinished();
	public abstract Season_Base GetNextSeason();
}