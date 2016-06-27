using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITime : MonoBehaviour {

	public static UITime Instance;

	Text textTime;

	float second = 60;

	void Awake () {
		Instance = this;

		textTime = transform.Find("Time").GetComponent<Text>();
	}

	void Update() {
		second -= Time.deltaTime;
		textTime.text = second.ToString("0.00");
	}
}
