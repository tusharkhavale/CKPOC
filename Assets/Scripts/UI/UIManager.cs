using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EGameState
{
	Title,
}

public class UIManager : MonoBehaviour {

	private GameObject titleScreen;
	public EGameState currState;

	/// <summary>
	/// Assign instance in GameController.
	/// </summary>
	void Start()
	{
		GameController.gameController.uiManager = this;
		LoadUIScreens ();
	}

	/// <summary>
	/// Loads the user interface screen refrences.
	/// </summary>
	void LoadUIScreens()
	{
//		titleScreen = transform.Find ("TitleScreen").gameObject;
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
