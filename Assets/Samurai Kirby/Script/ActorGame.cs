using UnityEngine;
using System;
using System.Collections;

public class ActorGame : MonoBehaviour {

	public static ActorGame Instance;

	GameObject goFox;
	GameObject goWalrus;

	public event Action actionGameFinished = () => {};

	void Awake() {
		Instance = this;

		goFox = transform.Find("Fox").gameObject;
		goWalrus = transform.Find("Walrus").gameObject;
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
		SpriteRenderer spriteRendererFox = goFox.GetComponent<SpriteRenderer>();
		spriteRendererFox.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_standby");
		SpriteRenderer spriteRendererWalrus = goWalrus.GetComponent<SpriteRenderer>();
		spriteRendererWalrus.sprite = spriteNokia;
	}

	public void OnWin() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_win");
		SpriteRenderer spriteRendererFox = goFox.GetComponent<SpriteRenderer>();
		spriteRendererFox.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_lose");
		SpriteRenderer spriteRendererWalrus = goWalrus.GetComponent<SpriteRenderer>();
		spriteRendererWalrus.sprite = spriteNokia;
	}

	public void OnLose() {
		Sprite spriteIphone = Resources.Load<Sprite>("iphone_lose");
		SpriteRenderer spriteRendererFox = goFox.GetComponent<SpriteRenderer>();
		spriteRendererFox.sprite = spriteIphone;

		Sprite spriteNokia = Resources.Load<Sprite>("nokia_win");
		SpriteRenderer spriteRendererWalrus = goWalrus.GetComponent<SpriteRenderer>();
		spriteRendererWalrus.sprite = spriteNokia;
	}
}
