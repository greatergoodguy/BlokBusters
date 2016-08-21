using UnityEngine;
using System.Collections;

public class GameUIFaceoff : MonoBehaviour {

	GameObject p1Face;
	GameObject p1Line;
	GameObject p2Face;
	GameObject p2Line;

	RectTransform p1FaceRT;
	RectTransform p1LineRT;
	RectTransform p2FaceRT;
	RectTransform p2LineRT;

	float duration = 2.0f;
	float rectWidth;

	float elapsedTime = 0;

	void Awake() {
		p1Face 	= transform.Find("Player 1 Face").gameObject;
		p1Line 	= transform.Find("Player 1 Line").gameObject;
		p2Face 	= transform.Find("Player 2 Face").gameObject;
		p2Line 	= transform.Find("Player 2 Line").gameObject;

		p1FaceRT = p1Face.GetComponent<RectTransform>();
		p1LineRT = p1Line.GetComponent<RectTransform>();
		p2FaceRT = p2Face.GetComponent<RectTransform>();
		p2LineRT = p2Line.GetComponent<RectTransform>();
	}
		
	void Start () {
		DisEngage();
	}

	void Update () {
		if (elapsedTime > duration) {
			return;
		}


		elapsedTime += Time.deltaTime;
		float fraction = elapsedTime / duration;

		{
			Vector3 tempPosition = p1FaceRT.position;
			tempPosition.x = Mathf.Lerp(0, rectWidth, fraction);
			p1FaceRT.position = tempPosition;
		}
		{
			Vector3 tempPosition = p1LineRT.position;
			tempPosition.x = Mathf.Lerp(1*rectWidth / 2, 3*rectWidth / 2, fraction);
			p1LineRT.position = tempPosition;
		}
		{
			Vector3 tempPosition = p2FaceRT.position;
			tempPosition.x = Mathf.Lerp(rectWidth, 0, fraction);
			p2FaceRT.position = tempPosition;
		}
		{
			Vector3 tempPosition = p2LineRT.position;
			tempPosition.x = Mathf.Lerp(1*rectWidth / 2, -1*rectWidth / 2, fraction);
			p2LineRT.position = tempPosition;
		}
	}

	public void DisEngage() {
		p1Face.Hide();
		p1Line.Hide();
		p2Face.Hide();
		p2Line.Hide();
	}

	public void Engage(float duration) {
		this.duration = duration;

		{
			Vector3 tempPosV3 = p1FaceRT.position;
			tempPosV3.x = 0;
			p1FaceRT.position = tempPosV3;

			Vector2 tempPosV2 = p1FaceRT.anchoredPosition;
			tempPosV2.y = 0;
			p1FaceRT.anchoredPosition = tempPosV2;
		}
		{
			Vector3 tempPosition = p1LineRT.position;
			tempPosition.x = 1*rectWidth / 2;
			p1LineRT.position = tempPosition;
		}
		{
			Vector3 tempPosition = p2FaceRT.position;
			tempPosition.x = rectWidth;
			tempPosition.y = 0;
			p2FaceRT.position = tempPosition;
		}
		{
			Vector3 tempPosition = p2LineRT.position;
			tempPosition.x = 1*rectWidth / 2;
			p2LineRT.position = tempPosition;
		}

		p1Face.Show();
		p1Line.Show();
		p2Face.Show();
		p2Line.Show();
	
		rectWidth = p1FaceRT.rect.width;
		elapsedTime = 0;
	}
}
