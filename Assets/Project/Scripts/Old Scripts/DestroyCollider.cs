using UnityEngine;
using System.Collections;

public class DestroyCollider : MonoBehaviour {

	public string[] tagsColliders;

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
				Death d = collider.gameObject.GetComponent<Death>();
				if(d != null)
					d.death();
				//Destroy(collider.gameObject);
			}
		}
	}
}
