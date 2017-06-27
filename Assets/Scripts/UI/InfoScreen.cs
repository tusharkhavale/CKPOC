using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour {

	Button btnGlobe;
	Button btnSound;
	Button btnNext;
	RawImage imgDisplay;
	string testImageUrl = "https://tushar-khavale.000webhostapp.com/Images/temp.jpg";

	void Start()
	{
		LoadUIReferences ();
		AssignButtonDelegates ();

	}

	void OnEnable()
	{
		GetImageFromURL (testImageUrl);
	}


	/// <summary>
	/// Loads the UI
	/// references from the scene.
	/// </summary>
	private void LoadUIReferences()
	{
		btnGlobe = transform.Find ("Globe").GetComponent<Button> ();
		btnSound = transform.Find ("Sound").GetComponent<Button> ();
		btnNext = transform.Find ("Next").GetComponent<Button> ();
		imgDisplay = transform.Find ("ImageFrame").GetComponentInChildren<RawImage> ();
	}

	/// <summary>
	/// Assigns button click delegates.
	/// </summary>
	private void AssignButtonDelegates()
	{
		btnGlobe.onClick.AddListener (this.OnCLickGlobe);
		btnSound.onClick.AddListener (this.OnClickSound);
		btnNext.onClick.AddListener (this.OnClickNext);
	}


#region Callback functions

	public void OnCLickGlobe()
	{
		GameController.gameController.TransitionToState (EGameState.Globe);
	}

	public void OnClickSound()
	{
		GameController.gameController.ToggleAudioOutput ();
	}

	public void OnClickNext()
	{
		GameController.gameController.TransitionToState (EGameState.SelectRecipe);
	}

#endregion


#region Fetch image from url

	/// <summary>
	/// Starts coroutine to fetch image from server
	/// </summary>
	/// <param name="url">URL.</param>
	public void GetImageFromURL(string url)
	{
		StartCoroutine(GetImage(url));
	}

	/// <summary>
	/// Gets the image.
	/// </summary>
	/// <param name="url">URL.</param>
	IEnumerator GetImage(string url)
	{
		UnloadImage();
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			if (www.texture != null)
			{
				imgDisplay.texture = www.texture;
				Destroy (www.texture);
			}
		} 
		else
		{
			Debug.Log ("Image loading failed");
		}
	}

	private void UnloadImage()
	{
		if (imgDisplay != null)
			Destroy (imgDisplay.texture);
	}
#endregion


}
