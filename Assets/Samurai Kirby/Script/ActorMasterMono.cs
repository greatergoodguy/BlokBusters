using UnityEngine;
using System.Collections;

public class ActorMasterMono : MonoBehaviour {

	public static ActorMasterMono Instance;

	void Awake() {
		Instance = this;
	}
}
