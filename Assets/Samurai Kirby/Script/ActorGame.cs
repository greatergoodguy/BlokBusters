using UnityEngine;
using System;
using System.Collections;

public class ActorGame : MonoBehaviour {

	public static ActorGame Instance;

	GameObject goPlayer1;
	GameObject goPlayer2;

	GameObject goPlayer1Start;
	GameObject goPlayer1Faceplant;
	GameObject goPlayer1End;
	GameObject goPlayer2Start;
	GameObject goPlayer2Faceplant;
	GameObject goPlayer2End;

	public event Action actionGameFinished = () => {};

	void Awake() {
		Instance = this;

		goPlayer1 = transform.Find("Player 1").gameObject;
		goPlayer2 = transform.Find("Player 2").gameObject;

		goPlayer1Start 		= transform.Find("Player 1 Start").gameObject;
		goPlayer1Faceplant 	= transform.Find("Player 1 Faceplant").gameObject;
		goPlayer1End 		= transform.Find("Player 1 End").gameObject;

		goPlayer2Start 		= transform.Find("Player 2 Start").gameObject;
		goPlayer2Faceplant 	= transform.Find("Player 2 Faceplant").gameObject;
		goPlayer2End 		= transform.Find("Player 2 End").gameObject;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset();
		}
	}

	public void Reset() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_standby");
		SpriteRenderer srIphone = goPlayer1.GetComponent<SpriteRenderer>();
		srIphone.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_standby");
		SpriteRenderer srNokia = goPlayer2.GetComponent<SpriteRenderer>();
		srNokia.sprite = spriteNokia;

		goPlayer1.SetPos(goPlayer1Start);
		goPlayer2.SetPos(goPlayer2Start);
	}

	public void OnWinPlayerOne() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_win");
		SpriteRenderer srIphone = goPlayer1.GetComponent<SpriteRenderer>();
		srIphone.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_lose");
		SpriteRenderer srNokia = goPlayer2.GetComponent<SpriteRenderer>();
		srNokia.sprite = spriteNokia;

		goPlayer1.SetPos(goPlayer1End);
		goPlayer2.SetPos(goPlayer2End);
	}

	public void OnWinPlayerOneByPremature() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_win");
		SpriteRenderer srIphone = goPlayer1.GetComponent<SpriteRenderer>();
		srIphone.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_faceplant");
		SpriteRenderer srNokia = goPlayer2.GetComponent<SpriteRenderer>();
		srNokia.sprite = spriteNokia;

		goPlayer1.SetPos(goPlayer1Start);
		goPlayer2.SetPos(goPlayer2Faceplant);
	}

	public void OnWinPlayerTwo() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_lose");
		SpriteRenderer srIphone = goPlayer1.GetComponent<SpriteRenderer>();
		srIphone.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_win");
		SpriteRenderer srNokia = goPlayer2.GetComponent<SpriteRenderer>();
		srNokia.sprite = spriteNokia;

		goPlayer1.SetPos(goPlayer1End);
		goPlayer2.SetPos(goPlayer2End);
	}
		
	public void OnWinPlayerTwoByPremature() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_faceplant");
		SpriteRenderer srIphone = goPlayer1.GetComponent<SpriteRenderer>();
		srIphone.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_win");
		SpriteRenderer srNokia = goPlayer2.GetComponent<SpriteRenderer>();
		srNokia.sprite = spriteNokia;

		goPlayer1.SetPos(goPlayer1Faceplant);
		goPlayer2.SetPos(goPlayer2Start);
	}

	public void OnWinNoone() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_faceplant");
		SpriteRenderer srIphone = goPlayer1.GetComponent<SpriteRenderer>();
		srIphone.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_faceplant");
		SpriteRenderer srNokia = goPlayer2.GetComponent<SpriteRenderer>();
		srNokia.sprite = spriteNokia;

		goPlayer1.SetPos(goPlayer1Start);
		goPlayer2.SetPos(goPlayer2Start);
	}
}
