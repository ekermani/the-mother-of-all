using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;
using System;

public class fireSerial : MonoBehaviour
{

	//	public static SerialPort sp = new SerialPort("/dev/tty.usbmodemFA131", 9600);

	private SerialPort serialPort = null;
	private string portName = "/dev/tty.usbmodemFD121";
	private int baudRate = 9600;
	private int readTimeOut = 100;
	public float currentZero; 

	//	private float amt = 0.010f;
	//	public float time;

	public ParticleSystem flamesParticleEffect;

	//	private string serialInput;
	private byte serialInput;

	bool programActive = true;
	Thread thread;

	void Start ()
	{
//		ParticleSystem ps = GetComponent<ParticleSystem> ();
//		var em = ps.emission;

		try {
			serialPort = new SerialPort ();
			serialPort.PortName = portName;
			serialPort.BaudRate = baudRate;
			serialPort.ReadTimeout = readTimeOut;   
			serialPort.Open ();
		} catch (Exception e) {
			Debug.Log (e.Message);
		}
		thread = new Thread (new ThreadStart (ProcessData));
		thread.Start ();
	}

	System.Object serialInputLock = new System.Object ();

	void ProcessData ()
	{
		Debug.Log ("Thread: Start");
		while (programActive) {
			try {
				if (serialPort.BytesToRead > 0) {
					lock (serialInputLock) {
//						serialInput = serialPort.ReadLine ();
						serialInput = (byte)serialPort.ReadByte ();
//						Debug.Log ("serialInput");
					}
				}
			} catch (TimeoutException) {

			}
		}
		Debug.Log ("Thread: Stop");
	}

	void Update ()
	{
//		string[] strEul;
//		strEul = serialInput.Split (',');

		byte eul;
		float pressThreshold = 20;

		lock (serialInputLock) {
//			if (serialInput != null) {
//				strEul = serialInput.Split (',');
			eul = serialInput;

//				Debug.Log (strEul[0]);
			Debug.Log (serialInput);


			currentZero = Mathf.Lerp (currentZero, eul, 0.1f);

			if (Mathf.Abs (currentZero - eul) > pressThreshold) {
					
				transform.GetComponent<ParticleSystem> ().Play (true);

			} else {
				transform.GetComponent<ParticleSystem> ().Stop (true, ParticleSystemStopBehavior.StopEmitting);
			}

//				if (strEul.Length > 0) {
//					if (int.Parse (strEul [0]) == 1) {
			//					if (int.Parse (strEul [0]) != 0) {

			//										transform.position.GetComponent<MeshRenderer> ().enabled = true;
			//										transform.position += new Vector3 (0, 0, amt*int.Parse (strEul [0]));

			//										transform.GetComponent<MeshRenderer> ().enabled = true;
			//					var temp = transform.GetComponent<ParticleSystem> ().emission;
			//					temp.enabled = true;
//						transform.GetComponent<ParticleSystem> ().Play (true);

//					} else {
//						transform.GetComponent<ParticleSystem> ().Stop (true, ParticleSystemStopBehavior.StopEmitting);

			//										transform.position.GetComponent<MeshRenderer> ().enabled = false;
			//										transform.GetComponent<MeshRenderer> ().enabled = false;
			//										transform.GetComponent<ParticleSystem> ().emission.enabled = false;
//					}
//				}
//			}
		}
	}

	//
	//	public void OnDisable ()
	//	{
	//		programActive = false;
	//		if (serialPort != null && serialPort.IsOpen)
	//			serialPort.Close ();
	//	}
}
