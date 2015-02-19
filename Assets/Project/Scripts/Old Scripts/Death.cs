using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public float timeAutoDestroy = 30f; //tempo para se auto destruir desde o momento em que nasceu
	public float timeDestroy = 2f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeAutoDestroy);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void death()
	{
		Destroy(gameObject);
	}
}
