using UnityEngine;
using System.Collections;

public class HitDamage : MonoBehaviour {

	public LayerMask targetLayer;
	public float damage;
	public bool melee = true;
	public GameObject target;
	public bool trigger = false;
	// Use this for initialization
	private Health h;

	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (trigger && melee) {

			h = target.GetComponent<Health>();
			if(h != null){
				h = target.GetComponent<Health>();
				h.Damage(damage);
			}
			trigger=false;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if ((targetLayer.value & (1<<other.gameObject.layer))!=0) {

		if(!melee){
			h = target.GetComponent<Health>();
			if(h != null){

				h.Damage(damage);
			}
			Destroy(gameObject);
		}
		}
	}

}