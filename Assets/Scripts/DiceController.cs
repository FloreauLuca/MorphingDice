using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
	private Rigidbody myRigidbody = null;
	private Camera mainCamera = null;
	[SerializeField] private float force = 100.0f;
	[SerializeField] private float mouseDist = 5.0f;
	private int currentScore = 0;
	private bool isPlaned;

	public int CurrentScore
	{
		get { return currentScore; }
	}

	public bool IsPlaned
	{
		get { return isPlaned; }
	}

	private void Start()
	{
		myRigidbody = GetComponent<Rigidbody>();
		mainCamera = Camera.main;
		Input.gyro.enabled = true;
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition =
				mainCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.one * mouseDist);
			Debug.DrawLine(transform.position, mousePosition);
			Vector3 dir = (mousePosition - transform.position) * force;
			myRigidbody.AddForce(dir);
		}

		Vector3 acceleration = new Vector3(Input.gyro.userAcceleration.x, Input.gyro.userAcceleration.z, Input.gyro.userAcceleration.y);
		UnityEngine.Debug.Log(acceleration);
		myRigidbody.AddForce(acceleration * force);

		UpdateScore();
	}

	void UpdateScore()
	{
		isPlaned = myRigidbody.angularVelocity.magnitude < 0.01f;
		int forward = Mathf.RoundToInt(Vector3.Dot(Vector3.up, transform.forward));
		if (forward == 1)
		{
			currentScore = 3;
			return;
		}
		else if (forward == -1)
		{
			currentScore = 4;
			return;
		}
		int up = Mathf.RoundToInt(Vector3.Dot(Vector3.up, transform.up));
		if (up == 1)
		{
			currentScore = 2;
			return;
		}
		else if (up == -1)
		{
			currentScore = 5;
			return;
		}
		int right = Mathf.RoundToInt(Vector3.Dot(Vector3.up, transform.right));
		if (right == 1)
		{
			currentScore = 6;
			return;
		}
		else if (right == -1)
		{
			currentScore = 1;
			return;
		}
	}
}
