using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var hitCombat = hit.GetComponent<Combat>();
		if (hitCombat != null)
		{
			hitCombat.TakeDamage(10);
			Destroy(gameObject);
		}
	}
}
