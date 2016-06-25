using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScore : MonoBehaviour {

	public static UIScore Instance;

	Text textScoreP1;
	Text textScoreP2;

	int scoreP1 = 0;
	int scoreP2 = 0;

	void Awake () {
		Instance = this;

		textScoreP1 = transform.Find("P1").GetComponent<Text>();
		textScoreP2 = transform.Find("P2").GetComponent<Text>();
	}

	public void AddScore(Player player, int score) {
		if(player == Player.Player1 || player == Player.Player1Keyboard) {
			scoreP1 += score;
			textScoreP1.text = "P1: " + scoreP1;
		}

		if (player == Player.Player2 || player == Player.Player2Keyboard) {
			scoreP2 += score;
			textScoreP2.text = "P2: " + scoreP2;
		}
	}
}
