using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	/// <summary>
	/// Start coroutine.
	/// </summary>
	void Start()
	{
		StartCoroutine (TrasitToGlobeScreen());		
	}

	/// <summary>
	/// Trasits to globe screen.
	/// </summary>
	/// <returns>The to globe screen.</returns>
	IEnumerator TrasitToGlobeScreen()
	{
		yield return new WaitForSeconds (Constants.TITLE_WAIT_TIME);
		GameController.gameController.TransitionToState (EGameState.Globe);
	}
}
