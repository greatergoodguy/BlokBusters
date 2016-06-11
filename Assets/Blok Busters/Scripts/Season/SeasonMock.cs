using UnityEngine;
using System.Collections;

public class SeasonMock : Season_Base {

	private static SeasonMock instance;
	private SeasonMock() {}
	public static SeasonMock Instance {
		get 
		{
			if (instance == null) {
				instance = new SeasonMock();}

			return instance;
		}
	}

	public override void Enter() {}
	public override void Update() {}
	public override void Exit() {}

	public override bool IsFinished() {
		return false;
	}

	public override Season_Base GetNextSeason() {
		return SeasonMock.Instance;
	}
}