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
	private GameObject character;


	void Start()
	{
		LoadUIRefrences ();
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



}
