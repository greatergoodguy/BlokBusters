using UnityEngine;
using System.Collections;

public enum Player {
	Player1,
	Player1Keyboard,
	Player2,
}

public class Hero : MonoBehaviour {

	[SerializeField] private LayerMask whatIsGround;
	private Transform tGroundCheck;    // A position marking where to check if the player is grounded.
	const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool isGrounded; 

	HeroState_Base heroState;

	public HeroState_Base stateMove = new HeroStateMove();
	public HeroState_Base stateJump = new HeroStateJump();
	public HeroState_Base stateAttack = new HeroStateAttack();

	public Player player;
	public Controller_Base controller;

	Hero.Assistant assistant;

	void Awake() {
		tGroundCheck = transform.Find("GroundCheck");

		heroState = stateMove;

		if (player == Player.Player1) {
			controller = new ControllerPlayer1();
		} else if (player == Player.Player1Keyboard) {
			controller = new ControllerPlayer1Keyboard();
		} else if (player == Player.Player2) {
			controller = new ControllerPlayer2();
		} else {
			controller = new ControllerPlayer1();
		}

		assistant = new Assistant(this);
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

	void ChangeState(HeroState_Base stateNew) {
		heroState.Exit();
		Toolbox.Log(heroState.GetType().Name + ": Exit");
		heroState = stateNew;
		heroState.Enter(assistant);
		Toolbox.Log(heroState.GetType().Name + ": Enter");
	}

	public class Assistant {

		Hero hero;

		public Hero Hero { get { return hero; } }
		public Rigidbody2D Rigidbody2D { get; private set; }
		public Transform Transform { get; private set; }
		public bool IsGrounded { get { return hero.isGrounded;} }
		public Controller_Base Controller { get { return hero.controller; } }

		public bool IsFacingRight { get; set; }

		public Assistant(Hero hero) {
			this.hero = hero;

			Rigidbody2D = hero.GetComponent<Rigidbody2D>();
			Transform = hero.GetComponent<Transform>();

			IsFacingRight = true;
		}

		public void ChangeState(HeroState_Base stateNew) {
			hero.ChangeState(stateNew);
		}
	}
}
