using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Camera;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - Camera.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Camera.transform.position + offset;
		
	}
}
// Main.camera.transform.position