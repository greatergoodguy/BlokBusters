using UnityEngine;
using System.Collections;

public class BlackPaint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Dizzy") {
			Sprite spriteDizzyBlack = Resources.Load<Sprite>("dizzy_walk_black");

			SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = spriteDizzyBlack;

			other.tag = "Dizzy Black";
		}
	}
}
