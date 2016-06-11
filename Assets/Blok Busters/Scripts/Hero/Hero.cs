using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public static Hero Instance;

	HeroState_Base heroState = HeroStateMove.Instance;
	Hero.Assistant assistant;

	[SerializeField] private LayerMask whatIsGround;
	private Transform tGroundCheck;    // A position marking where to check if the player is grounded.
	const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool isGrounded; 

	void Awake() {
		tGroundCheck = transform.Find("GroundCheck");
		assistant = new Assistant(this);
		Instance = this;
	}

	void Start () {
		heroState.Enter(assistant);
		Toolbox.Log(heroState.GetType().Name + ": Enter");
	}

	void Update () {
		heroState.Update();

		if(heroState.IsFinished()) {
			heroState.Exit();
			Toolbox.Log(heroState.GetType().Name + ": Exit");
			heroState = heroState.GetNextState();
			heroState.Enter(assistant);
			Toolbox.Log(heroState.GetType().Name + ": Enter");
		}
	}

	void FixedUpdate() {
		isGrounded = false;
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(tGroundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				isGrounded = true;
				//Toolbox.Log("FixedUpdate: isGrounded = true");
			}
		}

		heroState.FixedUpdate();
	}


	public class Assistant {

		Hero hero;

		public Rigidbody2D Rigidbody2D { get; private set; }
		public Transform Transform { get; private set; }
		public bool IsGrounded { get { return hero.isGrounded;} }

		public Assistant(Hero hero) {
			this.hero = hero;

			Rigidbody2D = hero.GetComponent<Rigidbody2D>();
			Transform = hero.GetComponent<Transform>();
		}
	}
}
