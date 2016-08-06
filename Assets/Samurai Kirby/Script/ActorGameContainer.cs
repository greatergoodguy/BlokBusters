using UnityEngine;
using System.Collections;

public class ActorGameContainer : MonoBehaviour {

	public static ActorGameContainer Instance;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
