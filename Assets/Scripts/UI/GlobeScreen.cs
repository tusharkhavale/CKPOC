﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobeScreen : MonoBehaviour {

	private Button btnSettings;
	private Button btnCountries;
	private Button btnSearch;
	private Button btnFav;
	private Button btnPopupOk;
	private Button btnPopupBack;
	public GameObject globe;

	private InputField inputCountry;
	private GameObject countryScrollView;
	private Transform grid;
	private GameObject character;
	private GameObject popup;
	private Object countryItem;
	List <GameObject> CountryItemList = new List<GameObject>(); 
	private bool toggleCountrySearch;
	private static Vector3 rightPosition = new Vector3 (0.4f, 1.0f, -8.0f);
	private static Vector3 defaultPosition = new Vector3 (0.0f, 1.0f, -8.0f);


	void Start()
	{
		LoadUIRefrences ();
		AssignButtonDelegates ();
		LoadCountryItem ();
	}

	void OnEnable()
	{
		ResetVariables ();
	}

	/// <summary>
	/// Resets class variables.
	/// </summary>
	private void ResetVariables()
	{
		toggleCountrySearch = false;
		globe.transform.position = defaultPosition;
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
		popup = transform.Find ("Popup").gameObject;
		btnPopupOk = popup.transform.Find ("Ok").GetComponent<Button> ();
		btnPopupBack = popup.transform.Find ("Back").GetComponent<Button> ();
		grid = countryScrollView.transform.Find ("Viewport").Find("Content");
	}

	/// <summary>
	/// Assigns the button delegates.
	/// </summary>
	private void AssignButtonDelegates()
	{
		btnSettings.onClick.AddListener (this.OnClickSettings);
		btnCountries.onClick.AddListener (this.OnClickCountries);
		btnFav.onClick.AddListener (this.OnClickFav);
		btnSearch.onClick.AddListener (this.OnClickSearch);
		inputCountry.onValueChanged.AddListener (this.OnInputChanged);
		btnPopupOk.onClick.AddListener (this.OnClickPopupOk);
		btnPopupBack.onClick.AddListener (this.OnClickPopupBack);
	}


	#region Button callbacks

	public void OnClickSettings()
	{
		Debug.Log("Settings");
	}

	public void OnClickSearch()
	{
		GameController.gameController.CurrCountry = Country.NONE;
		GameController.gameController.TransitionToState (EGameState.SelectRecipe);
	}

	public void OnClickCountries()
	{
		if (toggleCountrySearch)
			HideCountriesList ();
		else 
			ShowCountriesList ();

		toggleCountrySearch = !toggleCountrySearch;
	}

	public void OnClickFav()
	{
		Debug.Log ("Fav");
	}

	public void OnInputChanged(string value)
	{
		value = value.ToLower();
		foreach (GameObject go in CountryItemList) 
		{
			if (string.IsNullOrEmpty (value))
				go.SetActive (true);
			else if(!go.name.ToLower().Contains(value))
				go.SetActive (false);
			else 
				go.SetActive (true);
		}
	}

	public void OnClickPopupOk()
	{
		HidePopup ();
		GameController.gameController.TransitionToState (EGameState.Info);
	}

	public void OnClickPopupBack()
	{
		GameController.gameController.CurrCountry = Country.NONE;
		HidePopup ();
	}

	#endregion

	/// <summary>
	/// Enable InputField and countries scroll list.
	/// </summary>
	private void ShowCountriesList()
	{
		inputCountry.gameObject.SetActive (true);
		countryScrollView.gameObject.SetActive (true);
		StopAllCoroutines ();
		MoveGlobe(rightPosition);
	}

	/// <summary>
	/// Enable InputField and countries scroll list.
	/// </summary>
	private void HideCountriesList()
	{
		inputCountry.gameObject.SetActive (false);
		countryScrollView.gameObject.SetActive (false);
		StopAllCoroutines ();
		MoveGlobe(defaultPosition);
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

	/// <summary>
	/// Show country selection pop-up.
	/// </summary>
	/// <param name="country">Country.</param>
	public void CountrySelected(Country country)
	{
		GameController.gameController.CurrCountry = country;
		HideCountriesList ();
		ShowPopup ();
		(popup.transform.GetComponentInChildren<Text> ()).text = "Proceed with " + country.ToString (); 
	}

	/// <summary>
	/// Enable the Popup.
	/// </summary>
	private void ShowPopup()
	{
		popup.SetActive (true);
	}

	/// <summary>
	/// Disable the Popup .
	/// </summary>
	private void HidePopup()
	{
		popup.SetActive (false);
	}

	private void MoveGlobe(Vector3 destination)
	{
		StopAllCoroutines ();
		StartCoroutine (LerpGlobe (destination));
	}

	/// <summary>
	/// Translates the globe to new destination.
	/// </summary>
	/// <returns>The globe.</returns>
	/// <param name="destination">Destination.</param>
	IEnumerator LerpGlobe(Vector3 destination)
	{
		while (globe.transform.position.x != destination.x) 
		{
			globe.transform.position = Vector3.Lerp (globe.transform.position, destination, 0.1f);
			yield return null;
		}
	}


}
