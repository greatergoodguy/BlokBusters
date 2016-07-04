using UnityEngine;
using System.Collections;

public class ActorCamera : MonoBehaviour {

	public GameObject target;
	public GameObject boundLeft;
	public GameObject boundBottom;

	private Vector3 targetInitialPos;
	private Vector3 cameraInitialPos;

	// Use this for initialization
	void Start () {
		if (target == null) {
			return;
		}

		targetInitialPos = target.transform.position;
		cameraInitialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}

		Vector3 newPosition = transform.position;

		if (!target.IsLeftOf(boundLeft)) {
			newPosition.x = target.transform.position.x - targetInitialPos.x + cameraInitialPos.x;
		}

		if (target.IsAbove(boundBottom)) {
			newPosition.y = target.transform.position.y - boundBottom.transform.position.y + cameraInitialPos.y;
		}

		transform.position = newPosition;
	}
}
