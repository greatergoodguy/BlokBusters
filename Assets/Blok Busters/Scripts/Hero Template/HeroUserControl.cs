using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (HeroCharacter))]
public class HeroUserControl : MonoBehaviour {

	private HeroCharacter hero;
	private bool isJump;

	private void Awake() {
		hero = GetComponent<HeroCharacter>();
	}

	void Start () {
	
	}

	private void Update() {
		if (!isJump) {
			isJump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
	}

	private void FixedUpdate() {
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		hero.Move(h, crouch, isJump);
		isJump = false;
	}
}
