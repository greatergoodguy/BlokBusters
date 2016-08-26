using UnityEngine;
using System.Collections;

public class SetiDecorMatchesForOnePlayer : SetiDecorMatches {

	float[] reactionTimes;
	SetiGameOnePlayer setiGameOnePlayer;

	public SetiDecorMatchesForOnePlayer(SetiGameOnePlayer setiGameOnePlayer, int matchesTotal) : base(setiGameOnePlayer, matchesTotal) {
		this.setiGameOnePlayer = setiGameOnePlayer;

		if (matchesTotal == 1) {
			reactionTimes = new[] { 0.86f };
		} else if (matchesTotal == 3) {
			reactionTimes = new[] { 1.5f, 0.66f, 0.33f };
		} else if (matchesTotal == 5) {
			reactionTimes = new[] { 1.5f, 0.66f, 0.4f, 0.3f, 0.2f };
		} else if (matchesTotal == 7) {
			reactionTimes = new[] { 1.5f, 0.66f, 0.4f, 0.33f, 0.26f, 0.2f, 0.18f };
		} else if (matchesTotal == 9) {
			reactionTimes = new[] { 1.5f, 0.66f, 0.4f, 0.33f, 0.26f, 0.22f, 0.20f, 0.18f, 0.16f };
		} else {
			reactionTimes = new[] { 1.5f, 1.3f, 1.1f, 0.9f, 0.7f, 0.6f, 0.5f, 0.4f, 0.3f };
		}
	}

	public override void Enter() {
		base.Enter();

		float reactionTime = reactionTimes[matchesPlayed - 1];
		Toolbox.Log("reactionTime: " + reactionTime);
		setiGameOnePlayer.SetAIReactionTime(reactionTime);
	}
}
