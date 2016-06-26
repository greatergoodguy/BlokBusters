using UnityEngine;
using System.Collections;

public class GeneConveyorBelt : MonoBehaviour {

	public float speed = 2.0f;

	Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		rigidBody.position -= Vector2.right * speed * Time.deltaTime;
		rigidBody.MovePosition (rigidBody.position + Vector2.right * speed * Time.deltaTime);
	}
}
