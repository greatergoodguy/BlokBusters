using UnityEngine;
using System.Collections;

public class GameUIFaceoffRemove : MonoBehaviour {

	GameObject p1Face;
	GameObject p2Face;

	RectTransform p1FaceRT;
	RectTransform p2FaceRT;

	float duration = 2.0f;
	float rectHeight;

	float elapsedTime = int.MaxValue;

	void Awake() {
		p1Face 	= transform.Find("Player 1 Face").gameObject;
		p2Face 	= transform.Find("Player 2 Face").gameObject;

		p1FaceRT = p1Face.GetComponent<RectTransform>();
		p2FaceRT = p2Face.GetComponent<RectTransform>();
	}
		
	void Update () {
		if (elapsedTime > duration) {
			return;
		}


		elapsedTime += Time.deltaTime;
		float fraction = elapsedTime / duration;

		{
			Vector2 tempPos = p1FaceRT.anchoredPosition;
			tempPos.y = Mathf.Lerp(0, rectHeight, fraction);
			p1FaceRT.anchoredPosition = tempPos;
		}
		{
			Vector3 tempPosition = p2FaceRT.position;
			tempPosition.y = Mathf.Lerp(0, -rectHeight, fraction);
			p2FaceRT.position = tempPosition;
		}
	}

	void DisEngage() {
		p1Face.Hide();
		p2Face.Hide();
	}

	public void Engage(float duration) {
		this.duration = duration;

		p1Face.Show();
		p2Face.Show();
	
		rectHeight = p1FaceRT.rect.height;
		elapsedTime = 0;
	}
}
