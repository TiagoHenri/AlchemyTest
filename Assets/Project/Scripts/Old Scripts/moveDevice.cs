using UnityEngine;
using System.Collections;

public class moveDevice : MonoBehaviour {

	public Vector3 translate2;
	public Vector3 rotation2;

	private bool isPressed = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void activate(bool state)
	{
		if(!isPressed)
		{
			transform.Translate(translate2);
			transform.Rotate(rotation2);
			isPressed = !isPressed;
		}
		else
		{
			transform.Rotate(-rotation2);
			transform.Translate(-translate2);
			isPressed = !isPressed;
		}


	}
}
