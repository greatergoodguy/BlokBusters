using UnityEngine;
using System.Collections;

public class SetiGameTwoPlayersMatches : SetiGameTwoPlayers {

	public static SetiGameTwoPlayersMatches Instance = new SetiGameTwoPlayersMatches();

	int matchesTotal;
	int matchesPlayed;

	public void Reset(int matchesTotal) {
		this.matchesTotal = matchesTotal;
		matchesPlayed = 0;
	}

	public override SeTi_Base GetNextSeason() {
		matchesPlayed++;
		if (matchesPlayed < matchesTotal) { 
			return this;} 
		else { 
			return SetiTitleScreen.Instance;}
	}
}
