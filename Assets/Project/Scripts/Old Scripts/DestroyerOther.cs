using UnityEngine;
using System.Collections;

public class DestroyerOther : MonoBehaviour {

	public string[] tagsColliders;
	public Transform destroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{

		foreach(string tag in tagsColliders)
		{
			if(collider.tag == tag)
			{
				Death d = destroy.gameObject.GetComponent<Death>();
				if(d != null)
					d.death();
				//Destroy(collider.gameObject);
			}
		}
	}
}
