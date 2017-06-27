using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRecipeScreen : MonoBehaviour {

	private Button btnPrevious;
	private Button btnGlobe;
	private Button btnSound;
	private Button btnNext;
	private RawImage displayImage;
	private Transform gridIngredients;
	private Transform gridTools;
	private Object ingredientItem;
	private Object toolItem;
	private List<GameObject> lstIngredients = new List<GameObject>();
	private List<GameObject> lstTools = new List<GameObject>();

	/// <summary>
	/// Loads UI refrences.
	/// Assigns button delegates
	/// </summary>
	void Awake()
	{
		LoadUIReferences ();
		AssignButtonDelegates ();
	}

	/// <summary>
	/// Unload all scroll items
	/// Load ingredients and tools scroll list
	/// </summary>
	void OnEnable()
	{
		ResetVariables ();
		LoadIngredients ();
		LoadTools ();
	}

	/// <summary>
	/// Unload all scroll items on load.
	/// </summary>
	private void ResetVariables()
	{
		foreach (GameObject go in lstIngredients) 
		{
			Destroy (go);
		}
		lstIngredients.Clear();
		foreach (GameObject go in lstTools) 
		{
			Destroy (go);
		}
		lstTools.Clear();
	}

	/// <summary>
	/// Loads the UI references.
	/// </summary>
	private void LoadUIReferences()
	{
		btnPrevious = transform.Find ("Previous").GetComponent<Button> ();
		btnSound = transform.Find ("Sound").GetComponent<Button> ();
		btnGlobe = transform.Find ("Globe").GetComponent<Button> ();
		btnNext = transform.Find ("Next").GetComponent<Button> ();
		displayImage = transform.Find ("ImageFrame").GetComponentInChildren<RawImage> ();
		gridIngredients = transform.Find("IngredientsScrollView").Find ("Viewport").Find ("Content");
		gridTools = transform.Find("ToolsScrollView").Find ("Viewport").Find ("Content");
	}

	/// <summary>
	/// Assigns button delegates.
	/// </summary>
	private void AssignButtonDelegates()
	{
		btnPrevious.onClick.AddListener (this.OnClickPrevious);
		btnNext.onClick.AddListener (this.OnClickNext);
		btnGlobe.onClick.AddListener (this.OnClickGlobe);
		btnSound.onClick.AddListener (this.OnClickSound);
	}


	/// <summary>
	/// Adds ingredients to the scroll list.
	/// </summary>
	private void LoadIngredients()
	{
		Recipe currRecipe = GameController.gameController.CurrRecipe;

		displayImage.texture = currRecipe.texture;

		ingredientItem = Resources.Load<Object> ("Prefabs/ScrollViewItems/IngredientItem");

		for (int i = 0; i < currRecipe.ingredients.Length; i++) 
		{
			GameObject go = Instantiate (ingredientItem) as GameObject;
			(go.transform.GetComponentInChildren<Text> ()).text = currRecipe.ingredients[i];
			go.transform.SetParent (gridIngredients);
			go.transform.localScale = Vector3.one;
			lstIngredients.Add (go);	
		}
	}

	/// <summary>
	/// Adds tools to the scroll list
	/// </summary>
	private void LoadTools()
	{
		Recipe currRecipe = GameController.gameController.CurrRecipe;
		toolItem = Resources.Load<Object> ("Prefabs/ScrollViewItems/ToolItem");

		for (int i = 0; i < currRecipe.tools.Length; i++) 
		{
			GameObject go = Instantiate (toolItem) as GameObject;
			(go.transform.GetComponentInChildren<Text> ()).text = currRecipe.tools[i];
			go.transform.SetParent (gridTools);
			go.transform.localScale = Vector3.one;
			lstTools.Add (go);	
		}
	}


#region Callback functions

	public void OnClickGlobe()
	{
		GameController.gameController.TransitionToState (EGameState.Globe);
	}

	public void OnClickSound()
	{
		GameController.gameController.ToggleAudioOutput ();
	}

	public void OnClickNext()
	{
		GameController.gameController.TransitionToState (EGameState.RecipeSteps);
	}

	public void OnClickPrevious()
	{
		GameController.gameController.TransitionToState (EGameState.SelectRecipe);
	}

#endregion


}
