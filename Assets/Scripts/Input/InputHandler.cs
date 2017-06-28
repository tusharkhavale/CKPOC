using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {
	public float m_rotateFactor = 0.1f;
	private bool mouseDown;
	void Update()
	{
		// Mouse wheel scroll
		if (Input.GetAxis ("Mouse ScrollWheel") != 0)
			OnMouseScroll (Input.GetAxis ("Mouse ScrollWheel"));

		if (Input.GetMouseButtonDown (0))
			mouseDown = true;
		if (Input.GetMouseButtonUp (0))
			mouseDown = false;

		if(mouseDown)
		{
			float x = Input.GetAxis ("Mouse X") * m_rotateFactor;
			float y = Input.GetAxis ("Mouse Y") * m_rotateFactor;

			transform.RotateAround (Vector3.up, -x);
			transform.RotateAround (Vector3.right, y);
		}
	}

	void OnMouseScroll(float value)
	{
		float cameraZ = Camera.main.transform.position.z + value;
		cameraZ = Mathf.Clamp (cameraZ, -10f, -9f);
		Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, cameraZ);
	}
}
