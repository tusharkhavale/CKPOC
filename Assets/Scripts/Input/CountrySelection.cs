using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountrySelection : MonoBehaviour {


	void OnMouseDown()
	{
		Debug.Log(gameObject.name+" is selected");
		(transform.GetComponent<MeshRenderer> ()).enabled = true; 
	}

}
