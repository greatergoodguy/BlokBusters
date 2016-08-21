using UnityEngine;
using System.Collections;

public class SetiGameFaceOff : SeTi_Base {

	public static SetiGameFaceOff Instance = new SetiGameFaceOff();

	SeTi_Base nextSeti = SeTiMock.Instance;

	GameUIFader uiFader;
	GameUIFaceoff uiFaceoff;
	GameUIFaceoffRemove uiFaceoffRemove;

	bool isFinished;

	public void Init(SeTi_Base nextSeti) {
		this.nextSeti = nextSeti;
	}

	public override void Enter() {
		ActorGameContainer gameContainer = ActorGameContainer.Instance;
		gameContainer.Show();

		uiFader = gameContainer.GetComponentInChildren<GameUIFader>();
		uiFaceoff = gameContainer.GetComponentInChildren<GameUIFaceoff>();
		uiFaceoffRemove = gameContainer.GetComponentInChildren<GameUIFaceoffRemove>();

		isFinished = false;

		ActorGame game = gameContainer.GetComponentInChildren<ActorGame>();
		game.Reset();

		ActorMasterMono.Instance.StartCoroutine(FaceOff());
	}

	IEnumerator FaceOff() {
		ActorSFX.Instance.Stop(5);
		uiFaceoff.DisEngage();

		uiFader.Fade(1.5f);
		yield return new WaitForSeconds(1.5f);

		ActorSFX.Instance.Play(5);
		uiFaceoff.Engage(1.5f);
		yield return new WaitForSeconds(2.0f);

		uiFaceoffRemove.Engage(1.5f);
		yield return new WaitForSeconds(1.5f);

		uiFader.UnFade(1.5f);
		yield return new WaitForSeconds(1.5f);

		isFinished = true;
	}


	public override void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			ActorMasterMono.Instance.StopAllCoroutines();
			ActorMasterMono.Instance.StartCoroutine(FaceOff());
		}
	}

	public override bool IsFinished() {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason() {
		return nextSeti;
	}
}
