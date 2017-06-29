using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

	[HideInInspector]
	public GameObject selectedCountry;

	/// <summary>
	/// Disable any selected country on enable
	/// </summary>
	void OnEnable()
	{
		DisablePreviosCountry ();
	}

	/// <summary>
	/// Assigns new country gameobject as selected country
	/// </summary>
	/// <param name="go">Go.</param>
	public void CountrySelected (GameObject go)
	{
		DisablePreviosCountry ();
		selectedCountry = go;
	}

	/// <summary>
	/// Disables the previously selected country.
	/// </summary>
	private void DisablePreviosCountry()
	{
		if(selectedCountry != null)
			(selectedCountry.transform.GetComponent<MeshRenderer> ()).enabled = false;
	}

}
