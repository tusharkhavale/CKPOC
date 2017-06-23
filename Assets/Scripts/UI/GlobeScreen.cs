using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobeScreen : MonoBehaviour {

	private Button btnSettings;
	private Button btnCountries;
	private Button btnSearch;
	private Button btnFav;

	private InputField inputCountry;
	private GameObject countryScrollView;
	private Transform grid;
	private GameObject character;
	private Object countryItem;
	List <GameObject> CountryItemList = new List<GameObject>(); 


	void Start()
	{
		LoadUIRefrences ();
		AssignButtonDelegates ();
		LoadCountryItem ();
	}

	/// <summary>
	/// Loads the user interface 
	/// refrences from the screen.
	/// </summary>
	private void LoadUIRefrences()
	{
		btnSettings = transform.Find ("Settings").GetComponent<Button>();
		btnCountries = transform.Find ("Countries").GetComponent<Button>();
		btnFav = transform.Find ("Fav").GetComponent<Button>();
		btnSearch = transform.Find ("Search").GetComponent<Button>();

		inputCountry = transform.Find ("CountryInput").GetComponent<InputField> ();
		countryScrollView = transform.Find ("CountryScrollView").gameObject;
		character = transform.Find ("Character").gameObject;

		grid = countryScrollView.transform.Find ("Viewport").Find("Content");
	}

	private void AssignButtonDelegates()
	{
		btnSettings.onClick.AddListener (this.OnClickSettings);
		btnCountries.onClick.AddListener (this.OnClickCountries);
		btnFav.onClick.AddListener (this.OnClickFav);
		btnSearch.onClick.AddListener (this.OnClickSearch);
		inputCountry.onValueChanged.AddListener (this.OnInputChanged);
	}


	#region Button callbacks

	public void OnClickSettings()
	{
		Debug.Log("Settings");
	}

	public void OnClickSearch()
	{
		GameController.gameController.TransitionToState (EGameState.SelectRecipe);
	}

	public void OnClickCountries()
	{
		ShowCountriesList ();
	}

	public void OnClickFav()
	{
		Debug.Log ("Fav");
	}

	public void OnInputChanged(string value)
	{
		Debug.Log ("" + value);	
	}

	#endregion

	/// <summary>
	/// Enable InputField and countries scroll list.
	/// </summary>
	private void ShowCountriesList()
	{
		inputCountry.gameObject.SetActive (true);
		countryScrollView.gameObject.SetActive (true);
	}

	/// <summary>
	/// Enable InputField and countries scroll list.
	/// </summary>
	private void HideCountriesList()
	{
		inputCountry.gameObject.SetActive (false);
		countryScrollView.gameObject.SetActive (false);
	}

	/// <summary>
	/// Loads all Countries items to the scroll list.
	/// </summary>
	private void LoadCountryItem()
	{
		countryItem = Resources.Load<Object> ("Prefabs/ScrollViewITems/CountryItem");

		Country[] countryArray = System.Enum.GetValues (typeof(Country)) as Country[];
		for (int i = 0; i < countryArray.Length; i++) 
		{
			GameObject go = Instantiate (countryItem) as GameObject;
			go.name = countryArray [i].ToString();
			(go.transform.GetComponent<Text> ()).text = go.name;
			go.transform.SetParent (grid);
			go.transform.localScale = Vector3.one;
			CountryItemList.Add (go);	
		}
	}





}
