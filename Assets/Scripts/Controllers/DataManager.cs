using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;


class Data
{
	public Recipe[] recipes;
}

public class DataManager : MonoBehaviour {

	private Dictionary <Country, List<Recipe>> dictCountryRecipe = new Dictionary<Country, List<Recipe>>();
	private List<Recipe> lstRecipe = new List<Recipe> ();
	private string recipeJSON;
	static string testUrl = "https://tushar-khavale.000webhostapp.com/data/DummyText.txt";


	void Start()
	{
		GameController.gameController.dataManager = this;
		GetRecipeFromSerevr (testUrl);
	}

#region Get recipe data from server

	public void GetRecipeFromSerevr(string url)
	{
		StartCoroutine(GetRecipe(url));
	}

	/// <summary>
	/// Gets the image.
	/// </summary>
	/// <param name="url">URL.</param>
	IEnumerator GetRecipe(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			if (www.texture != null)
			{
				recipeJSON = www.text;
				LoadRecipeData (recipeJSON);
			}
		} 
		else
		{
			Debug.Log ("Data loading failed");
		}
	}

#endregion 

	/// <summary>
	/// Parse the JSON
	/// Populate the list
	/// Populate the dictionary
	/// </summary>
	/// <param name="json">Json.</param>
	private void LoadRecipeData(string json)
	{
		//Prase JSON
		Data data = JsonMapper.ToObject<Data> (json);

		for (int i = 0; i < data.recipes.Length; i++) 
		{
			//Populate list with recipes
			lstRecipe.Add (data.recipes [i]);

			//Populate dictionary with Country-Recipe
			Country country = ((Country) System.Enum.Parse (typeof (Country), data.recipes[i].country));
			// create new key if not available
			if (!dictCountryRecipe.ContainsKey (country))
				dictCountryRecipe.Add(country,new List<Recipe>());
				
				dictCountryRecipe [country].Add (data.recipes [i]);
		}
	}

	/// <summary>
	/// Gets the recipe by country.
	/// </summary>
	/// <returns>The recipe by country.</returns>
	/// <param name="country">Country.</param>
	public List<Recipe> GetRecipeByCountry(Country country)
	{
		if (dictCountryRecipe.ContainsKey (country))
			return dictCountryRecipe [country];
		else
			return null;
	}

	/// <summary>
	/// Gets all recipes.
	/// </summary>
	/// <returns>lstRecipe</returns>
	public List<Recipe> GetAllRecipes()
	{
		return lstRecipe;
	}


}
