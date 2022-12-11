using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveAround : MonoBehaviour
{

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3;
	public float limit = 80; 
	public float zoom = 0.25f; 
	public float zoomMax = 10; 
	public float zoomMin = 3; 
	private float x, y;

	void Start()
	{
		limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
		transform.position = target.position + offset;
	}

	void Update()
	{
		if (Input.GetMouseButton(0)) { 
			x = transform.localEulerAngles.y + Input.GetAxis("Mouse x") * sensitivity;
			y += Input.GetAxis("Mouse y") * sensitivity;
			y = Mathf.Clamp(y, -limit, limit);
			transform.localEulerAngles = new Vector3(-y, x, 0);
			transform.position = transform.localRotation * offset + target.position;
	}
	}
}