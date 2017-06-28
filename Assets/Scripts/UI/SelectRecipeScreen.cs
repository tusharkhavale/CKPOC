using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRecipeScreen : MonoBehaviour {

	private Button btnPrevious;
	private Button btnGlobe;
	private Button btnSearch;
	private InputField input;
	private Transform grid;
	private Object recipeItem;
	private List<GameObject> lstRecipesItems = new List<GameObject>();
	private List<Recipe> lstRecipes = new List<Recipe>();

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
	/// Load Recipes on enable.
	/// </summary>
	void OnEnable()
	{
		ResetVariables ();	
		lstRecipes = GameController.gameController.GetRecipes ();
		if(lstRecipes != null)
			LoadRecipes (lstRecipes);
	}

	/// <summary>
	/// Resets the variables.
	/// Flush all scroll items and Recipe list
	/// </summary>
	private void ResetVariables()
	{
		foreach (GameObject go in lstRecipesItems) 
		{
			Destroy (go);
		}
		lstRecipesItems.Clear();
		lstRecipes.Clear();	
	}

	/// <summary>
	/// Loads the UI references.
	/// </summary>
	private void LoadUIReferences()
	{
		btnPrevious = transform.Find ("Previous").GetComponent<Button>();
		btnGlobe = transform.Find ("Globe").GetComponent<Button>();
		btnSearch = transform.Find("Search").GetComponent<Button>();
		input = transform.Find ("InputField").GetComponent<InputField> ();
		grid = transform.Find ("RecipeScrollView").Find ("Viewport").Find ("Content");
	}

	/// <summary>
	/// Assings the button delegates.
	/// </summary>
	private void AssignButtonDelegates()
	{
		btnPrevious.onClick.AddListener (this.OnClickPrevious);
		btnGlobe.onClick.AddListener (this.OnClickGlobe);
		btnSearch.onClick.AddListener (this.OnClickSearch);
		input.onValueChanged.AddListener (this.OnInputChanged);
	}

	/// <summary>
	/// Instantiates and adds recipe items to the list.
	/// </summary>
	/// <param name="list">List.</param>
	private void LoadRecipes(List<Recipe> list)
	{
		if(recipeItem == null)
			recipeItem = Resources.Load<Object> ("Prefabs/ScrollViewItems/RecipeItem");

		foreach (Recipe recipe in list) 
		{
			GameObject go = Instantiate (recipeItem) as GameObject;
			go.name = recipe.name;
			go.GetComponent<RecipeItem> ().recipe = recipe;
			(go.transform.GetComponentInChildren<Text> ()).text = go.name;
			go.transform.SetParent (grid);
			go.transform.localScale = Vector3.one;
			lstRecipesItems.Add (go);	
		}
	}


#region callback functions

	public void OnClickGlobe()
	{
		GameController.gameController.TransitionToState (EGameState.Globe);
	}

	public void OnClickSearch()
	{
		if (input.gameObject.activeInHierarchy)
			input.gameObject.SetActive (false);
		else
			input.gameObject.SetActive (true);
	}

	public void OnClickPrevious()
	{
		GameController.gameController.TransitionToState (EGameState.Info);
	}

	public void OnInputChanged(string value)
	{
		foreach (GameObject go in lstRecipesItems) 
		{
			if (string.IsNullOrEmpty (value))
				go.SetActive (true);
			else if(!go.name.Contains(value))
				go.SetActive (false);
			else 
				go.SetActive (true);
		}
	}

#endregion

}
