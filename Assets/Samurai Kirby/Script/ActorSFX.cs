using UnityEngine;
using System.Collections;

public class ActorSFX : MonoBehaviour {

	public static ActorSFX Instance;

	AudioSource[] audioSources;

	void Awake() {
		Instance = this;

		audioSources = GetComponents<AudioSource>();
	}

	public void Play(int index) {
		if (index < 0 || index >= audioSources.Length) {
			return;
		}

		audioSources[index].Play();
	}


	public void Stop(int index) {
		if (index < 0 || index >= audioSources.Length) {
			return;
		}

		audioSources[index].Stop();
	}
}
