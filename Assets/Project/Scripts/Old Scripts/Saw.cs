using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

	public int speed = 300;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, -speed));
	}
}
