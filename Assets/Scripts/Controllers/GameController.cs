using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController gameController;
	private Country currCountry;
	private Recipe currRecipe;

	[HideInInspector]
	public InputManager inputManager;

	[HideInInspector]
	public UIManager uiManager;

	[HideInInspector]
	public  DataManager dataManager;

	[HideInInspector]
	public SoundManager soundManager;

	void Awake()
	{
		gameController = this;
	}

	/// <summary>
	/// Gets or sets the curr country.
	/// </summary>
	/// <value>The curr country.</value>
	public Country CurrCountry
	{
		get{ return currCountry;}
		set{ currCountry = value;}
	}

	/// <summary>
	/// Gets or sets the curr recipe.
	/// </summary>
	/// <value>The curr recipe.</value>
	public Recipe CurrRecipe
	{
		get{ return currRecipe;}
		set{ currRecipe = value;}
	}

	/// <summary>
	/// Transitions the game state.
	/// </summary>
	/// <param name="state">State.</param>
	public void TransitionToState(EGameState state)
	{
		uiManager.TransitionToState (state);
	}

	/// <summary>
	/// Toggles the audio output.
	/// </summary>
	public void ToggleAudioOutput()
	{
		soundManager.ToggleAudioOutput ();
	}

	/// <summary>
	/// Gets the recipe by country.
	/// </summary>
	/// <returns>The recipe by country.</returns>
	public List<Recipe> GetRecipes()
	{
		if (CurrCountry == Country.NONE)
			return dataManager.GetAllRecipes ();
		else
			return dataManager.GetRecipeByCountry (CurrCountry);
	}
}
