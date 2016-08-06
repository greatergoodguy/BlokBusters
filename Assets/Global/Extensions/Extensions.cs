using UnityEngine;
using System.Collections;

public static class Extensions {

	public static void Hide(this MonoBehaviour monoBehaviour) {
		monoBehaviour.gameObject.SetActive(false);
	}

	public static void Show(this MonoBehaviour monoBehaviour) {
		monoBehaviour.gameObject.SetActive(true);
	}

	public static void Hide(this GameObject gameObject) {
		gameObject.SetActive(false);
	}

	public static void Show(this GameObject gameObject) {
		gameObject.SetActive(true);
	}

	public static void SetPos(this GameObject gameObject, Transform transform) {
		gameObject.SetPos(transform.position.x, transform.position.y, transform.position.z);
	}

	public static void SetPos(this GameObject gameObject, float posX, float posY, float posZ) {
		gameObject.transform.SetPos(posX, posY, posZ);
	}

	public static void SetPos(this MonoBehaviour monoBehvaiour, float posX, float posY, float posZ) {
		monoBehvaiour.transform.SetPos(posX, posY, posZ);
	}

	public static void SetPos(this Transform transform, float posX, float posY, float posZ) {
		Vector3 positionTemp = transform.position;
		positionTemp.x = posX;
		positionTemp.y = posY;
		positionTemp.z = posZ;
		transform.position = positionTemp;
	}

	public static bool HasA<T>(this Component component) {
		return component.GetComponent<T>() != null;
	}

	public static bool HasA<T>(this Collision collision) {
		return collision.collider.HasA<T>();
	}

	public static bool HasA<T>(this Collision2D collision) {
		return collision.collider.HasA<T>();
	}

	public static bool IsLeftOf(this GameObject gameObject, GameObject target) {
		if (target == null) {
			return false;
		}
		return gameObject.transform.position.x < target.transform.position.x;
	}

	public static bool IsRightOf(this GameObject gameObject, GameObject target) {
		return !IsLeftOf(gameObject, target);
	}

	public static bool IsBelow(this GameObject gameObject, GameObject target) {
		if (target == null) {
			return false;
		}
		return gameObject.transform.position.y < target.transform.position.y;
	}

	public static bool IsAbove(this GameObject gameObject, GameObject target) {
		return !IsBelow(gameObject, target);
	}
}
