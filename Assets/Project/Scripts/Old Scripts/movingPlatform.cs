using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

	public Vector3 trans;
	public float CD = 2f;

	private float time;

	// Use this for initialization
	void Start () {
		time = CD;
	}
	
	// Update is called once per frame
	void Update () {

		if(time > 0)
		{
			time -= Time.deltaTime;
		}
		else 
		{
			trans *= -1;
			time = CD;
		}

		transform.position += new Vector3(trans.x, trans.y, trans.z) * Time.deltaTime;
	}
}
