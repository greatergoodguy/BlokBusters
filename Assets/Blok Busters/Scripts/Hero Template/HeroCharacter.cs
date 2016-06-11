using UnityEngine;
using System.Collections;

public class HeroCharacter : MonoBehaviour {

	public static HeroCharacter Instance;

	[SerializeField] private float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float jumpForce = 400f;                  // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[SerializeField] private bool isAirControl = false;               // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;                  // A mask determining what is ground to the character

	private Transform tGroundCheck;    // A position marking where to check if the player is grounded.
	const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool isGrounded;            // Whether or not the player is grounded.
	private Transform tCeilingCheck;   // A position marking where to check for ceilings
	const float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D rigidbody2D;
	private bool isFacingRight = true;  // For determining which way the player is currently facing.

	void Awake () {
		Instance = this;

		tGroundCheck = transform.Find("GroundCheck");
		tCeilingCheck = transform.Find("CeilingCheck");
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Start () {
	
	}

	private void FixedUpdate() {
		isGrounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(tGroundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				isGrounded = true;
			}
		}
	}

	void Update () {
	
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch) {
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(tCeilingCheck.position, ceilingRadius, whatIsGround)) {
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (isGrounded || isAirControl) {
			// Reduce the speed if crouching by the crouchSpeed multiplier
			move = (crouch ? move * crouchSpeed : move);

			// Move the character
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !isFacingRight) {
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && isFacingRight) {
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (isGrounded && jump) {
			// Add a vertical force to the player.
			isGrounded = false;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}

	private void Flip() {
		// Switch the way the player is labelled as facing.
		isFacingRight = !isFacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
