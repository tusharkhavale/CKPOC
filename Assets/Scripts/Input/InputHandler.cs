using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private float m_rotateFactor = 0.1f;
	private bool mouseDown;
	public float m_scaleFactor = 0.005f;
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.


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


		// Pinch to zoom
		// If there are two touches on the device...         
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			Zoom (deltaMagnitudeDiff);
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			float x = Input.GetAxis ("Mouse X") * m_rotateFactor;
			float y = Input.GetAxis ("Mouse Y") * m_rotateFactor;

			transform.RotateAround (Vector3.up, -x);
			transform.RotateAround (Vector3.right, y);
		}
#endif
	}

#if UNITY_WEBGL || UNITY_WEBGL_API
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

#else
		
	/// <summary>
	/// Zoom the specified magnitude.
	/// </summary>
	/// <param name="magnitude">Magnitude.</param>
	void Zoom(float magnitude)
	{
		transform.localScale = new Vector3 (transform.localScale.x - magnitude*m_scaleFactor, 
		transform.localScale.y - magnitude*m_scaleFactor,
		transform.localScale.z - magnitude*m_scaleFactor);
	}

#endif




}
