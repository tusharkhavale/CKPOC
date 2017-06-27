using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeItem : MonoBehaviour {

	private Button button;
	private RawImage image;
	public Recipe recipe;

	/// <summary>
	/// Load display image on start.
	/// </summary>
	void Start()
	{
		LoadUIRefrences ();
		GetImageFromURL (recipe.imageUrl);
	}

	/// <summary>
	/// Loads the UI refrences.
	/// </summary>
	private void LoadUIRefrences()
	{
		button = transform.GetComponent<Button> ();
		image = transform.GetComponentInChildren<RawImage> ();
		button.onClick.AddListener (OnClickItem);
	}

	/// <summary>
	/// Button callback function.
	/// </summary>
	public void OnClickItem()
	{
		GameController.gameController.CurrRecipe = recipe;
		GameController.gameController.TransitionToState (EGameState.ShowRecipe);
	}

#region Fetch image from url

	/// <summary>
	/// Assigns downloaded texture is available or
	/// Starts coroutine to fetch image from server
	/// </summary>
	/// <param name="url">URL.</param>
	private void GetImageFromURL(string url)
	{
		if (recipe.texture != null)
			image.texture = recipe.texture;
		else
			StartCoroutine(GetImage(url));
	}

	/// <summary>
	/// Gets the image.
	/// </summary>
	/// <param name="url">URL.</param>
	IEnumerator GetImage(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			if (www.texture != null)
			{
				image.texture = www.texture;
				recipe.texture = www.texture;
				Destroy (www.texture);
			}
		} 
	}
#endregion
}
