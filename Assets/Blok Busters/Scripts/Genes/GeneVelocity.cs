using UnityEngine;
using System.Collections;

public class GeneVelocity : MonoBehaviour {

	public float X { get { return velocityX; }  }
	public float Y { get { return velocityY; }  }

	public float velocityX = 5.0f;
	public float velocityY = 0.0f;

	void Update () {
		transform.Translate(new Vector2(velocityX * Time.deltaTime, velocityY * Time.deltaTime));
	}

	public void SetVelocity(float velocityX, float velocityY) {
		this.velocityX = velocityX;
		this.velocityY = velocityY;
	}
}
