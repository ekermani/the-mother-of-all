using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;
using System;

public class handMovement : MonoBehaviour {

//	public static SerialPort sp = new SerialPort("/dev/tty.usbmodemFA131", 9600);

	private SerialPort serialPort = null;
	private string portName = "/dev/tty.usbmodemFA131";
	private int baudRate =  9600;             
	private int readTimeOut = 100;  
	private float amt = 0.010f;
	public float speed;

	private string serialInput;

	bool programActive = true;
	Thread thread;

	void Start () {
		try
		{
			serialPort = new SerialPort();
			serialPort.PortName = portName;
			serialPort.BaudRate = baudRate;
			serialPort.ReadTimeout = readTimeOut;   
			serialPort.Open();
		}
		catch (Exception e) {
			Debug.Log (e.Message);
		}
		thread = new Thread(new ThreadStart(ProcessData));
		thread.Start();
	}

	void ProcessData(){
		Debug.Log ("Thread: Start");
		while (programActive) {
			try {
				serialInput = serialPort.ReadLine();
			} catch (TimeoutException) {

			}
		}
		Debug.Log ("Thread: Stop");
	}

	void Update () {
		if (serialInput != null) {
			string[] strEul= serialInput.Split (',');
			Debug.Log (strEul [0]);
			if (strEul.Length > 0) {
				if (int.Parse (strEul [0]) >= 15) {
//					if (int.Parse (strEul [0]) != 0) {
						
//					transform.position.GetComponent<MeshRenderer> ().enabled = true;
					transform.position += new Vector3 (0, 0, amt*int.Parse (strEul [0]));

//					transform.position += new Vector3 (0, amt*int.Parse (strEul [0]), 0);

//					transform.GetComponent<MeshRenderer> ().enabled = true;
//					this.GetComponent<MeshRenderer> ().enabled = true;	
//				} else {
//					transform.position.GetComponent<MeshRenderer> ().enabled = false;
////					this.GetComponent<MeshRenderer> ().enabled = false;
////
					/// NEED TO CHANGE SO THAT WHEN GETS DATA 
					/// MOVES FOR A CERTAIN AMOUNT OF TIME
				}
			}
		}
	}

	public void OnDisable(){
		programActive = false;   
		if (serialPort != null && serialPort.IsOpen) 
			serialPort.Close ();
	}
}

//	public float speed;

//	void Start () 

//	public float speed;  // --> make speed smooth/floaty
//
//	private Rigidbody rb;
//
////	public Transform;
//
//	void Start () { 
//		rb = GetComponent<Rigidbody>();
//	}
//
//
//	void FixedUpdate () {
//
////		float moveHorizontal = Input.GetAxis ("Horizontal");
////		float moveVertical = Input.GetAxis ("Vertical");
//
//		if (Input.GetKey("space")) {
//			transform.Translate(new Vector3(speed * Time.deltaTime, 0,0));
//				}			   
//
////		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//
////		rb.AddForce (movement * speed); 
//
//	}
//}		