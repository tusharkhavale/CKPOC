using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource audioSource;

	void Start()
	{
		GameController.gameController.soundManager = this;
		LoadAudioSourceReference ();
	}

	/// <summary>
	/// Loads the audio source refrence.
	/// </summary>
	void LoadAudioSourceReference()
	{
		audioSource = transform.GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Toggles the audio output.
	/// </summary>
	public void ToggleAudioOutput()
	{
		audioSource.mute = !audioSource.mute;
	}
}
