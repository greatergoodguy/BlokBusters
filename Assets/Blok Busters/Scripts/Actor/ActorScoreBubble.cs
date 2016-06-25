using UnityEngine;
using System.Collections;

public class ActorScoreBubble : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Toolbox.Log("OnTriggerEnter2D - " + other.tag);

		if (other.tag == "Hero") {
			Destroy(gameObject);
		}
	}
}
