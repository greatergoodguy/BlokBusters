using UnityEngine;
using System.Collections;

public class GameUIFader : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	public void Fade(float duration) {
		GameObject goBlack = transform.Find("Black Overlay").gameObject;

		Destroy(goBlack.GetComponent<GeneFadeAlpha>());
		GeneFadeAlpha gene = goBlack.AddComponent<GeneFadeAlpha>();
		gene.Init(duration, 0.0f, 0.6f);
	}

	public void UnFade(float duration) {
		GameObject goBlack = transform.Find("Black Overlay").gameObject;

		Destroy(goBlack.GetComponent<GeneFadeAlpha>());
		GeneFadeAlpha gene = goBlack.AddComponent<GeneFadeAlpha>();
		gene.Init(duration, 0.6f, 0.0f);
	}
}
