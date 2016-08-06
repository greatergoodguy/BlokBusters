using UnityEngine;
using System.Collections;

public class SampleSeti : MonoBehaviour {

	public static readonly string TAG = typeof(SampleSeti).Name;

	SeTi_Base seasonOfTime = SeTiMock.Instance;

	void Start () {
		seasonOfTime.Enter();
		Debug.Log(TAG + seasonOfTime.GetType().Name + ": Enter");
	}

	void Update () {
		seasonOfTime.Update();

		if(seasonOfTime.IsFinished()) {
			seasonOfTime.Exit();
			Debug.Log(TAG + seasonOfTime.GetType().Name + ": Exit");
			seasonOfTime = seasonOfTime.GetNextSeason();
			seasonOfTime.Enter();
			Debug.Log(TAG + seasonOfTime.GetType().Name + ": Enter");
		}
	}
}
