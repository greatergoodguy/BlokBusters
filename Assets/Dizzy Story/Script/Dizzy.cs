using UnityEngine;
using System.Collections;

public class Dizzy : MonoBehaviour {

	public int forceScaler = 10;

	Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
		//rigidBody.AddForce(new Vector2(1, 0) * 1000);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.A)) {
			Toolbox.Log("Move Left");
			rigidBody.AddForce(new Vector2(-1, 0) * forceScaler);
		}
		if (Input.GetKey(KeyCode.D)) {
			Toolbox.Log("Move Right");
			rigidBody.AddForce(new Vector2(1, 0) * forceScaler);
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			Toolbox.Log("Move Left");
			rigidBody.AddForce(new Vector2(0, 1) * forceScaler);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			Toolbox.Log("Move Right");
			rigidBody.AddForce(new Vector2(0, -1) * forceScaler);
		}
	}
}
