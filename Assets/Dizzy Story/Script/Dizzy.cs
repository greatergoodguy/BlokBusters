using UnityEngine;
using System.Collections;

public class Dizzy : MonoBehaviour {

	public int forceScaler = 10;

	Rigidbody2D rigidBody;
	bool isFacingRight = true;
	float maxSpeed = 10f;
	float additiveMovementForce = 60f;
	float jumpForce = 1000f;

	bool isGrounded = false;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		float axisHorizontal 		= Input.GetAxis("Horizontal");
		float velXCurrent 			= rigidBody.velocity.x;
		float resistanceMultiplier 	= 3;

		if (velXCurrent <= maxSpeed && velXCurrent >= -maxSpeed) {
			rigidBody.AddForce(new Vector2(axisHorizontal * additiveMovementForce, 0));
		}
		else if (velXCurrent <= -maxSpeed && axisHorizontal > 0) {
			rigidBody.AddForce(new Vector2(axisHorizontal * additiveMovementForce, 0));
		}
		else if (velXCurrent >= maxSpeed && axisHorizontal < 0) {
			rigidBody.AddForce(new Vector2(axisHorizontal * additiveMovementForce, 0));
		}

		if (axisHorizontal > 0 && !isFacingRight) {
			Flip();
		}
		else if (axisHorizontal < 0 && isFacingRight) {			
			Flip();
		}

		if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
			rigidBody.AddForce(new Vector2(0f, jumpForce));
		}
	}

	private void Flip() {
		isFacingRight = !isFacingRight;

		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		isGrounded = true;
	}

	void OnCollisionExit2D(Collision2D collision) {
		isGrounded = false;
	}
}
