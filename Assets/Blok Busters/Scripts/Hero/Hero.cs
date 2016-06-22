using UnityEngine;
using System.Collections;

public enum Player {
	Player1,
	Player1Keyboard,
	Player2,
	Player2Keyboard,
}

public class Hero : MonoBehaviour {
	
	public Rigidbody2D Rigidbody2D { get; private set; }
	public Transform Transform { get; private set; }
	public bool IsGrounded { get; private set; }
	public Controller_Base Controller { get; private set; }
	
	public bool IsFacingRight { get; set; }

	[SerializeField] private LayerMask whatIsGround;
	private Transform tGroundCheck;    // A position marking where to check if the player is grounded.
	const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded

	HeroState_Base heroState;

	public HeroState_Base stateMove = new HeroStateMove();
	public HeroState_Base stateJump = new HeroStateJump();
	public HeroState_Base stateAttack = new HeroStateAttack();
	public HeroState_Base stateHurt = new HeroStateHurt();
	public HeroState_Base stateBounce = new HeroStateBounce();

	public Player player;

	void Awake() {
		tGroundCheck = transform.Find("GroundCheck");

		heroState = stateMove;

		Rigidbody2D = GetComponent<Rigidbody2D>();
		Transform = GetComponent<Transform>();
		IsGrounded = false;
		
		IsFacingRight = true;

		if (player == Player.Player1) 				{ Controller = new ControllerPlayer1();} 
		else if (player == Player.Player1Keyboard) 	{ Controller = new ControllerPlayer1Keyboard();} 
		else if (player == Player.Player2) 			{ Controller = new ControllerPlayer2();} 
		else if (player == Player.Player2Keyboard) 	{ Controller = new ControllerPlayer2Keyboard();} 
		else 										{ Controller = new ControllerPlayer1();}
	}

	void Start () {
		heroState.Enter(this);
		Toolbox.Log(heroState.GetType().Name + ": Enter");
	}

	void Update () {
		heroState.Update();

		if(heroState.IsFinished()) {
			heroState.Exit();
			Toolbox.Log(heroState.GetType().Name + ": Exit");
			heroState = heroState.GetNextState();
			heroState.Enter(this);
			Toolbox.Log(heroState.GetType().Name + ": Enter");
		}
	}

	void FixedUpdate() {
		IsGrounded = false;
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(tGroundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				IsGrounded = true;
			}
		}

		heroState.FixedUpdate();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Toolbox.Log("OnTriggerEnter2D: " + other.tag);
		if (other.tag == "Hurtable") {
			ChangeState(stateHurt);
		}
		else if (other.tag == "Bouncable") {
			ChangeState(stateBounce);
		}
	}

	public void ChangeState(HeroState_Base stateNew) {
		heroState.Exit();
		Toolbox.Log(heroState.GetType().Name + ": Exit");
		heroState = stateNew;
		heroState.Enter(this);
		Toolbox.Log(heroState.GetType().Name + ": Enter");
	}

	public void ChangeSprite(Sprite sprite) {
		GetComponent<SpriteRenderer>().sprite = sprite;
	}
}
