﻿using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Transform device;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			moveDevice m = device.GetComponent<moveDevice>();
			m.activate(true);
		}
	}
}
