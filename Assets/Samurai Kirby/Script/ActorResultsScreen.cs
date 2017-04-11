using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ActorResultsScreen : MonoBehaviour {

	public static ActorResultsScreen Instance;

	public event Action actionDone = () => {};

	GameObject goPanel;

	public void Show() {
		goPanel.SetActive(true);
	}

	public void Hide() {
		goPanel.SetActive(false);
	}

	void Awake() {
		Instance = this;

		goPanel = transform.Find("Panel").gameObject;
		if (goPanel == null) {
			goPanel = new GameObject();
		}
	}

	void Start () {
		this.Hide();
	}

	void Update () {
	
	}

	public void SetResults(float bestTime, int p1Wins, int p2Wins) {
		// Best Time
		Text textBestTime = transform.Find("Panel/Panel/Text Best Time").GetComponent<Text>();
		textBestTime.text = "Best Time: " + bestTime.ToString(Constants.TIME_FORMAT) + " seconds";
		Toolbox.Log("bestTime: " + bestTime);

		// Winner
		Text textWinner = transform.Find("Panel/Panel/Text Winner").GetComponent<Text>();
		if (p1Wins > p2Wins) {
			textWinner.text = "Winner: iPhone";
		}
		else {
			textWinner.text = "Winner: Nokia";
		}

		// Rounds
		Text textRounds = transform.Find("Panel/Panel/Text Rounds").GetComponent<Text>();
		if (p1Wins > p2Wins) {
			textRounds.text = "Won " + p1Wins + " rounds out of " + (p1Wins + p2Wins);
		}
		else {
			textRounds.text = "Won " + p2Wins + " rounds out of " + (p1Wins + p2Wins);
		}

		// iPhone Image
		Image imageIPhone = transform.Find("Panel/Panel/Image iPhone").GetComponent<Image>();
		if (p1Wins > p2Wins) {
			Sprite spriteIphone = Resources.Load<Sprite>("iphone_win");
			imageIPhone.sprite = spriteIphone;
		}
		else {
			Sprite spriteIphone = Resources.Load<Sprite>("iphone_lose");
			imageIPhone.sprite = spriteIphone;
		}

		// Nokia Image
		Image imageNokia = transform.Find("Panel/Panel/Image Nokia").GetComponent<Image>();
		if (p1Wins > p2Wins) {
			Sprite spriteIphone = Resources.Load<Sprite>("nokia_lose");
			imageNokia.sprite = spriteIphone;
		}
		else {
			Sprite spriteIphone = Resources.Load<Sprite>("nokia_win");
			imageNokia.sprite = spriteIphone;
		}
	}

	public void ButtonDone() {
		actionDone.Invoke();
	}
}
