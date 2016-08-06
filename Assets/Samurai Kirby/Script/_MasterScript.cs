using UnityEngine;
using System.Collections;

public class _MasterScript : MonoBehaviour {

	SeTi_Base seasonOfTime = SetiBigBang.Instance;

	void Start () {
		seasonOfTime.Enter();
		Toolbox.Log(seasonOfTime.GetType().Name + ": Enter");
	}

	void Update () {
		seasonOfTime.Update();

		if(seasonOfTime.IsFinished()) {
			seasonOfTime.Exit();
			Toolbox.Log(seasonOfTime.GetType().Name + ": Exit");
			seasonOfTime = seasonOfTime.GetNextSeason();
			seasonOfTime.Enter();
			Toolbox.Log(seasonOfTime.GetType().Name + ": Enter");
		}
	}
}
