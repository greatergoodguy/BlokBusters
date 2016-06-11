using UnityEngine;
using System.Collections;

public static class Extensions {
	public static void SetPos(this MonoBehaviour monoBehvaiour, float posX, float posY, float posZ) {
		monoBehvaiour.transform.SetPos(posX, posY, posZ);
	}

	public static void SetPos(this Transform transform, float posX, float posY, float posZ) {
		Vector3 positionTemp = transform.position;
		positionTemp.x = 0;
		positionTemp.y = 0;
		positionTemp.z = 0;
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
}
