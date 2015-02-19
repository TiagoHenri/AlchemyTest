using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject thing;
	public float timeInit;
	public float CD;

	void Start () {
		InvokeRepeating("spawn",timeInit,CD);
	}
	

	void Update () {
	
	}

	void spawn()
	{
		if(thing != null)
			Instantiate(thing, transform.position, Quaternion.identity);
		//setar a tag do inimigo ao spawnar um minion
	}
}
