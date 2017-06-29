using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private float m_rotateFactor = 0.1f;
	private bool mouseDown;

	/// <summary>
	/// Reset variables on Enable.
	/// </summary>
	void OnEnable()
	{
		mouseDown = false;
	}

	void Update()
	{

		#if UNITY_WEBGL || UNITY_WEBGL_API
		// Mouse wheel scroll 
		if (Input.GetAxis ("Mouse ScrollWheel") != 0)
			OnMouseScroll (Input.GetAxis ("Mouse ScrollWheel"));

		// Touch started trigger
		if (Input.GetMouseButtonDown (0))
			mouseDown = true;

		// Touch ended trigger
		if (Input.GetMouseButtonUp (0))
			mouseDown = false;


		if(mouseDown)
		{
			float x = Input.GetAxis ("Mouse X") * m_rotateFactor;
			float y = Input.GetAxis ("Mouse Y") * m_rotateFactor;

			transform.RotateAround (Vector3.up, -x);
			transform.RotateAround (Vector3.right, y);
		}
		#else
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			float x = Input.GetAxis ("Mouse X") * m_rotateFactor;
			float y = Input.GetAxis ("Mouse Y") * m_rotateFactor;

			transform.RotateAround (Vector3.up, -x);
			transform.RotateAround (Vector3.right, y);
		}
		#endif
	}

	/// <summary>
	/// Move the canera close to the globe to get zoom effect.
	/// </summary>
	/// <param name="value">Value.</param>
	void OnMouseScroll(float value)
	{
		float cameraZ = Camera.main.transform.position.z + value;
		cameraZ = Mathf.Clamp (cameraZ, -10f, -9f);
		Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, cameraZ);
	}
}
