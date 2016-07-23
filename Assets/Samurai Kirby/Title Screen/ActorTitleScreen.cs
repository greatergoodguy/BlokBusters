using UnityEngine;
using System.Collections;

public class ActorTitleScreen : MonoBehaviour {

	GameObject goPanel;

	void Awake() {
		goPanel = transform.Find("Panel").gameObject;
	}

	public void Show() {
		goPanel.SetActive(true);
	}

	public void Hide() {
		goPanel.SetActive(false);
	}
}
