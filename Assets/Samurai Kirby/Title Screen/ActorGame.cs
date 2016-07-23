using UnityEngine;
using System.Collections;

public class ActorGame : MonoBehaviour {

	GameObject goFox;
	GameObject goWalrus;

	void Awake() {
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
		Sprite[] spritesFox = Resources.LoadAll<Sprite>("foxes");
		SpriteRenderer spriteRendererFox = goFox.GetComponent<SpriteRenderer>();
		spriteRendererFox.sprite = spritesFox[0];

		Sprite[] spritesWalrus = Resources.LoadAll<Sprite>("walrus");
		SpriteRenderer spriteRendererWalrus = goWalrus.GetComponent<SpriteRenderer>();
		spriteRendererWalrus.sprite = spritesWalrus[3];
	}

	public void OnActionPressed() {
		Sprite[] spritesFox = Resources.LoadAll<Sprite>("foxes");
		SpriteRenderer spriteRendererFox = goFox.GetComponent<SpriteRenderer>();
		spriteRendererFox.sprite = spritesFox[1];

		Sprite[] spritesWalrus = Resources.LoadAll<Sprite>("walrus");
		SpriteRenderer spriteRendererWalrus = goWalrus.GetComponent<SpriteRenderer>();
		spriteRendererWalrus.sprite = spritesWalrus[1];
	}

	public void OnActionPressedEarly() {
		Sprite[] spritesFox = Resources.LoadAll<Sprite>("foxes");
		SpriteRenderer spriteRendererFox = goFox.GetComponent<SpriteRenderer>();
		spriteRendererFox.sprite = spritesFox[2];

		Sprite[] spritesWalrus = Resources.LoadAll<Sprite>("walrus");
		SpriteRenderer spriteRendererWalrus = goWalrus.GetComponent<SpriteRenderer>();
		spriteRendererWalrus.sprite = spritesWalrus[2];
	}
}
