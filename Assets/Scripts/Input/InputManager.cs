using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public  delegate void leftDelegate();
	private event leftDelegate leftEvent;

	public delegate void rightDelegate();
	private event rightDelegate rightEvent;

	public delegate void upDelegate();
	private event upDelegate upEvent;

	public delegate void downDelegate();
	private event downDelegate downEvent;

	public delegate void cheatDelegate();
	private event cheatDelegate cheatEvent;

	// Add-Remove delegates

	public void AddLeftDelegate(leftDelegate del)
	{
		leftEvent += del;
	}

	public void RemoveLeftDelegate(leftDelegate del)
	{
		leftEvent -= del;
	}

	public void AddRightDelegate(rightDelegate del)
	{
		rightEvent += del;
	}

	public void RemoveRightDelegate(rightDelegate del)
	{
		rightEvent -= del;
	}

	public void AddUpDelegate(upDelegate del)
	{
		upEvent += del;
	}

	public void RemoveUpDelegate(upDelegate del)
	{
		upEvent -= del;
	}

	public void AddDownDelegate(downDelegate del)
	{
		downEvent += del;
	}

	public void RemoveDownDelegate(downDelegate del)
	{
		downEvent -= del;
	}

	public void AddCheatDelegate(cheatDelegate del)
	{
		cheatEvent += del;
	}

	public void RemoveCheatDelegate(cheatDelegate del)
	{
		cheatEvent -= del;
	}

	/// <summary>
	/// Assign instance in GameController.
	/// </summary>
	void Start()
	{
		GameController.gameController.inputManager = this;
	}


	/// <summary>
	/// Update input events
	/// </summary>
	void Update()
	{
		// Cheat after crash
//		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.A))
//	    	cheatEvent ();
//
//		if (Input.GetKey(KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 			// Up
//			upEvent ();
//		else if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow))		// Down	
//			downEvent ();
//
//
//		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))			// left
//			leftEvent ();
//		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))		// Right
//			rightEvent ();
	}

}
