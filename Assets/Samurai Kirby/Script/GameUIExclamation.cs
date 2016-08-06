using UnityEngine;
using System.Collections;

public class GameUIExclamation : MonoBehaviour {

	GameObject goExclamation;

	// Use this for initialization
	void Awake () {
		goExclamation = transform.Find("Panel/Exclamation").gameObject;
	}

	void Start() {
		Hide();
	}

	public void Show() {
		goExclamation.Show();
	}

	public void Hide() {
		goExclamation.Hide();
	}
}
