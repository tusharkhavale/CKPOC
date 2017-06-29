using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountrySelection : MonoBehaviour {



	/// <summary>
	/// Raises the mouse down event.
	/// Shows country selected popup
	/// Assigns country selected Gameobject
	/// </summary>
	void OnMouseDown()
	{
		(transform.GetComponent<MeshRenderer> ()).enabled = true; 
		GameController.gameController.CountrySelected ((Country) System.Enum.Parse (typeof (Country), name));
		transform.GetComponentInParent<Earth> ().CountrySelected (this.gameObject);
	}

}
