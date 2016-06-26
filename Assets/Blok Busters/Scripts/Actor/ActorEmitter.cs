using UnityEngine;
using System.Collections;

public class ActorEmitter : MonoBehaviour {

	public GameObject gameObjectTemplate;
	public float emitRateInSecond = 5.0f;
	public bool emitOnStart = false;

	float elapsedTime = 0;

	public void Awake() {
		if (gameObjectTemplate == null) {
			return;
		}

		if (emitOnStart) {
			GameObject gameObject = GameObject.Instantiate<GameObject>(gameObjectTemplate);
			gameObject.transform.parent = transform.parent;
			gameObject.SetPos(transform);
		}
	}

	public void Update() {
		if (gameObjectTemplate == null) {
			return;
		}

		if (emitRateInSecond == 0) {
			return;
		}

		elapsedTime += Time.deltaTime;
		if (elapsedTime >= emitRateInSecond) {
			GameObject gameObject = GameObject.Instantiate<GameObject>(gameObjectTemplate);
			gameObject.transform.parent = transform.parent;
			gameObject.SetPos(transform);
			elapsedTime = 0;
		}
	}

	Vector3 gizmoSize = new Vector3(1, 1, 0);
	void OnDrawGizmos(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawCube(transform.position, gizmoSize);
	}

}
