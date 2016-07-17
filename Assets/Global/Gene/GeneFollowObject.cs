using UnityEngine;
using System.Collections;

public class GeneFollowObject : MonoBehaviour {

	public GameObject target;

	private Vector3 targetInitialPos;
	private Vector3 victimInitialPos;

	// Use this for initialization
	void Start () {
		if (target == null) {
			return;
		}

		targetInitialPos = target.transform.position;
		victimInitialPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}

		Vector3 newPosition = transform.position;
		newPosition.x = target.transform.position.x - targetInitialPos.x + victimInitialPos.x;
		newPosition.y = target.transform.position.y - targetInitialPos.y + victimInitialPos.y;
		transform.position = newPosition;
	}
}
