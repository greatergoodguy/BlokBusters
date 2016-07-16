using UnityEngine;
using System.Collections;

public class CreateAResource : MonoBehaviour {

	public string resourceName;

	void Awake() {
		GameObject goResource = Toolbox.Create(resourceName);
		goResource.SetPos(transform);
		goResource.transform.parent = transform.parent;
		Destroy(gameObject);
	}
}
