using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EGameState
{
	Title,
	Globe,
	Info,
	SelectRecipe,
	ShowRecipe,
	RecipeSteps,
}

public class UIManager : MonoBehaviour {


	// UI Screens
	private GameObject titleScreen;
	private GameObject globeScreen;
	private GameObject infoScreen;
	private GameObject selectRecipeScreen;
	private GameObject showRecipeScreen;
	private GameObject recipeStepsScreen;
	public GameObject globe;

	public EGameState currState;

	/// <summary>
	/// Assign instance in GameController.
	/// </summary>
	void Start()
	{
		GameController.gameController.uiManager = this;
		LoadUIScreenRefrences ();
		TransitionToState (currState);
	}

	/// <summary>
	/// Loads the user interface screen refrences.
	/// </summary>
	void LoadUIScreenRefrences()
	{
		titleScreen = transform.Find ("TitleScreen").gameObject;
		globeScreen = transform.Find ("GlobeScreen").gameObject;
		infoScreen = transform.Find ("InfoScreen").gameObject;
		selectRecipeScreen = transform.Find ("SelectRecipeScreen").gameObject;
		showRecipeScreen = transform.Find ("ShowRecipeScreen").gameObject;
		recipeStepsScreen = transform.Find ("RecipeStepsScreen").gameObject;
	}

	/// <summary>
	/// Transitions the Game State.
	/// </summary>
	/// <param name="state">State.</param>
	public void TransitionToState(EGameState state)
	{
		DisableScreen (currState);
		currState = state;
		EnableScreen (currState);
	}

	/// <summary>
	/// Enables the UI screen.
	/// </summary>
	/// <param name="state">State.</param>
	private void EnableScreen(EGameState state)
	{
		switch (state) 
		{
			case EGameState.Title:
				titleScreen.SetActive (true);
				break;
			case EGameState.Globe:
				globeScreen.SetActive (true);
				globe.SetActive (true);
				break;
			case EGameState.Info:
				infoScreen.SetActive (true);
				break;
			case EGameState.SelectRecipe:
				selectRecipeScreen.SetActive (true);
				break;
			case EGameState.ShowRecipe:
				showRecipeScreen.SetActive (true);
				break;
			case EGameState.RecipeSteps:
				recipeStepsScreen.SetActive (true);
				break;
		}
	}

	/// <summary>
	/// Disables the UI screen.
	/// </summary>
	/// <param name="state">State.</param>
	private void DisableScreen(EGameState state)
	{
		switch (state) 
		{
			case EGameState.Title:
				titleScreen.SetActive (false);
				break;
			case EGameState.Globe:
				globeScreen.SetActive (false);
				globe.SetActive (false);
				break;
			case EGameState.Info:
				infoScreen.SetActive (false);
				break;
			case EGameState.SelectRecipe:
				selectRecipeScreen.SetActive (false);
				break;
			case EGameState.ShowRecipe:
				showRecipeScreen.SetActive (false);
				break;
			case EGameState.RecipeSteps:
				recipeStepsScreen.SetActive (false);
				break;
		}
	}

	#region Click callback functions

	public void OnClickStart()
	{

	}

	public void OnClickDone()
	{
		
	}

	#endregion
}
