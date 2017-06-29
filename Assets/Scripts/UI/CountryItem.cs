using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryItem : MonoBehaviour {

	/// <summary>
	/// Assign button delegate on Start.
	/// </summary>
	void Start () {
		(transform.GetComponent<Button> ()).onClick.AddListener (this.OnClick);
	}

	/// <summary>
	/// Raises the click event.
	/// </summary>
	void OnClick()
	{
		GameController.gameController.CountrySelected ((Country) System.Enum.Parse (typeof (Country), name));
	}

}
