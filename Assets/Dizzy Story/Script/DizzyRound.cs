using UnityEngine;
using System.Collections;

public class DizzyRound : MonoBehaviour {

	public int forceScaler = 10;

	Rigidbody2D rigidBody;
	bool isFacingRight = true;
	float maxSpeedX = 14f;
	float additiveMovementForce = 20f;
	float jumpForce = 1000f;

	bool isGrounded = false;
	float velocityPreviousFrame;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float axisHorizontal 		= -Input.GetAxis("Horizontal");
		float velXCurrent 			= rigidBody.velocity.x;
		float resistanceMultiplier 	= 3;

		if (velXCurrent <= maxSpeedX && velXCurrent >= -maxSpeedX) {
			rigidBody.AddTorque(axisHorizontal * additiveMovementForce, ForceMode2D.Force);
		}
		else if (velXCurrent <= -maxSpeedX && axisHorizontal > 0) {
			rigidBody.AddTorque(axisHorizontal * additiveMovementForce, ForceMode2D.Force);
		}
		else if (velXCurrent >= maxSpeedX && axisHorizontal < 0) {
			rigidBody.AddTorque(axisHorizontal * additiveMovementForce, ForceMode2D.Force);
		}

//		if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
//			rigidBody.AddForce(new Vector2(0f, jumpForce));
//		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			rigidBody.AddForce(new Vector2(0f, jumpForce));
		}
			
		velocityPreviousFrame = rigidBody.velocity.magnitude;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Toolbox.Log("velocityPreviousFrame: " + velocityPreviousFrame);
		isGrounded = true;

		if (velocityPreviousFrame > 25.0f) {
			StartCoroutine(ShowWinnerScreenAndStartNextLevel());
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		isGrounded = false;
	}

	IEnumerator ShowWinnerScreenAndStartNextLevel() {
		GameObject goUIWinner = GameObject.Find("UI Winner");
		goUIWinner.transform.Find("Panel").gameObject.SetActive(true);

		yield return new WaitForSeconds(2);

		Application.LoadLevel("Level 1");
	}
}

