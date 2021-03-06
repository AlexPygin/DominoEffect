﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	private float rotateSpeed;
	private float shiftSpeed;
	private Vector3 oldPosition;
	private Quaternion oldRotation;
	private Vector3 tempPosition;
	private Quaternion tempRotation;
	public bool isOrthographic;
	

	void Start()
	{
		shiftSpeed = 1.0f;
		rotateSpeed = 3.0f;
		oldPosition = new Vector3 (0.0f, 20.0f, -20.0f);
		oldRotation = new Quaternion (0.4f, 0.0f, 0.0f, 0.9f);
	}

	public void changeCamera() {
		tempPosition = transform.position;
		tempRotation = transform.rotation;
		transform.position = oldPosition;
		transform.rotation = oldRotation;
		oldPosition = tempPosition;
		oldRotation = tempRotation;
		camera.orthographic = !camera.orthographic;
	}

	void Update ()
	{
		isOrthographic = camera.orthographic;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = 0.0f;
		float rotateHorizontal = Input.GetAxis ("Mouse X");
		float rotateVertical = Input.GetAxis ("Mouse Y");
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			changeCamera();
		}
		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			shiftSpeed = 1.5f;
		}
		else
		{
			shiftSpeed = 1.0f;
		}
		if (!camera.orthographic) {

			if (Input.GetKey (KeyCode.E)) {
				moveUp = 1.0f;
			}
			if (Input.GetKey (KeyCode.Q)) {
				moveUp = -1.0f;
			}
			if (Input.GetKey (KeyCode.R)) {
				transform.Rotate (-rotateVertical * rotateSpeed, 0.0f, 0.0f, Space.World);
			}
			
			if (Input.GetMouseButton (1)) {
				transform.Rotate (0.0f, rotateHorizontal * rotateSpeed, 0.0f, Space.World);
			}
			transform.Translate (moveHorizontal * shiftSpeed, moveUp * shiftSpeed, moveVertical * shiftSpeed);
		} 
		else 
		{
			if (Input.GetKey (KeyCode.E)) {
				camera.orthographicSize += 1.0f;
			}
			if (Input.GetKey (KeyCode.Q)) {
				camera.orthographicSize -= 1.0f;
			}
			camera.orthographicSize = Mathf.Clamp (camera.orthographicSize, 2.0f, 50.0f); 
			transform.Translate (moveHorizontal * shiftSpeed, moveVertical * shiftSpeed, 0.0f);
		}
		

	}


}