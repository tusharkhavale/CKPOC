using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeStepsScreen : MonoBehaviour {

	private Button btnPrevious;
	private Button btnGlobe;
	private Button btnSound;
	private Button btnDone;
	private Transform grid;
	private Object stepsItem;
	private List<GameObject> lstSteps = new List<GameObject>();

	/// <summary>
	/// Loads refrences and assigns delegates on awake.
	/// </summary>
	void Awake()
	{
		LoadUIReferences ();
		AssignButtonDelegates ();
	}

	/// <summary>
	/// Resets variables and Loads recipe steps .
	/// </summary>
	void OnEnable()
	{
		ResetVariables ();
		LoadRecipeSteps ();
	}

	/// <summary>
	/// Destroys previous steps item and clears Stepslist.
	/// </summary>
	private void ResetVariables()
	{
		foreach (GameObject go in lstSteps) 
		{
			Destroy (go);
		}
		lstSteps.Clear ();
	}

	/// <summary>
	/// Loads the UI references.
	/// </summary>
	private void LoadUIReferences()
	{
		btnPrevious = transform.Find ("Previous").GetComponent<Button> ();
		btnGlobe = transform.Find ("Globe").GetComponent<Button> ();
		btnSound = transform.Find ("Sound").GetComponent<Button> ();
		btnDone = transform.Find ("Done").GetComponent<Button> ();
		grid = transform.Find ("StepsScrollview").Find ("Viewport").Find ("Content");
	}

	/// <summary>
	/// Assigns button delegates.
	/// </summary>
	private void AssignButtonDelegates()
	{
		btnPrevious.onClick.AddListener (this.OnClickPrevious);
		btnDone.onClick.AddListener (this.OnClickDone);
		btnGlobe.onClick.AddListener (this.OnClickGlobe);
		btnSound.onClick.AddListener (this.OnClickSound);
	}


	/// <summary>
	/// Add recipe steps to the scroll view.
	/// </summary>
	private void LoadRecipeSteps()
	{
		Recipe currRecipe = GameController.gameController.CurrRecipe;
		if(stepsItem == null)
			stepsItem = Resources.Load<Object> ("Prefabs/ScrollViewItems/StepItem");

		for (int i = 0;i < currRecipe.steps.Length; i++) 
		{
			GameObject go = Instantiate (stepsItem) as GameObject;
			(go.transform.GetComponentInChildren<Text> ()).text = currRecipe.steps[i];
			go.transform.SetParent (grid);
			go.transform.localScale = Vector3.one;
			lstSteps.Add (go);	
		}
	}

#region Callback functions

	public void OnClickGlobe()
	{
		GameController.gameController.TransitionToState (EGameState.Globe);
	}

	public void OnClickPrevious()
	{
		GameController.gameController.TransitionToState (EGameState.ShowRecipe);
	}

	public void OnClickSound()
	{
		GameController.gameController.ToggleAudioOutput ();
	}

	public void OnClickDone()
	{
		GameController.gameController.TransitionToState (EGameState.Globe);
	}

#endregion
}
