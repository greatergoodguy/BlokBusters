using UnityEngine;
using System.Collections;

public class GeneSuicide : MonoBehaviour {

	public float lifetimeInSeconds = 3;
	float elapsedTime = 0;

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime > lifetimeInSeconds) {
			Destroy(gameObject);
		}
	}

	public void SetLifetime(float lifetimeInSeconds) {
		this.lifetimeInSeconds = lifetimeInSeconds;
	}
}
