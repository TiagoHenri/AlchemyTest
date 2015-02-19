using UnityEngine;
using System.Collections;

public class whenLevelLoaded : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//o que sera feito quando carregar o level numero "level"
	void OnLevelWasLoaded(int level)
	{
		if(level == 1)
		{
			//faca algo
		}
	}
}
