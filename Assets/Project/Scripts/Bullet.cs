using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 550f; 

	public int damage = 1;

	public string tag;

	void Start()
	{
		Destroy(gameObject, 6); //destroy after 10 seconds 
	}

	// Update is called once per frame
	void Update () 
	{
		rigidbody2D.velocity = new Vector2(speed * 15 * Time.deltaTime,0);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag.Equals(tag))	
		{
			Destroy(gameObject);
			Health health = collider.gameObject.GetComponent<Health>(); 

			if(health != null)
			{
				health.Damage(damage);
			}
		}
	}
}
