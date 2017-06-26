using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController gameController;

	[HideInInspector]
	public InputManager inputManager;

	[HideInInspector]
	public UIManager uiManager;

	void Awake()
	{
		gameController = this;
	}

	/// <summary>
	/// Transitions the game state.
	/// </summary>
	/// <param name="state">State.</param>
	public void TransitionToState(EGameState state)
	{
		uiManager.TransitionToState (state);
	}
}
