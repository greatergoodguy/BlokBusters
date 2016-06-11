using UnityEngine;
using System.Collections;

public class HeroStateMock : HeroState_Base {
	
	private static HeroStateMock instance;
	private HeroStateMock() {}
	public static HeroStateMock Instance {
		get {
			if (instance == null) {
				instance = new HeroStateMock();}

			return instance;
		}
	}
}
