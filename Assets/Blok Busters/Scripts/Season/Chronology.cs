using UnityEngine;
using System.Collections;

public class Chronology : MonoBehaviour {

	Season_Base seasonActive = SeasonGame.Instance;

	void Start () {
		seasonActive.Enter();
		Toolbox.Log(seasonActive.GetType().Name + ": Enter");
	}

	void Update () {
		seasonActive.Update();

		if(seasonActive.IsFinished()) {
			seasonActive.Exit();
			Toolbox.Log(seasonActive.GetType().Name + ": Exit");
			seasonActive = seasonActive.GetNextSeason();
			seasonActive.Enter();
			Toolbox.Log(seasonActive.GetType().Name + ": Enter");
		}
	}
}
