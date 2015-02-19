using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
public bool lookRight = false;
public LayerMask targetLayer;
public GameObject target;
public float vel =100f ;
private float orientation = 0;
public bool right = true;

void Start () {

				Destroy (gameObject, 8);
				//if (!lookRight){
			//	vel = -vel;
				
		//	}


	}
		
void FixedUpdate () {
	
	//transform.position += v*Time.deltaTime;
	//v += a * Time.deltaTime;
		orientation = Mathf.Atan2(transform.position.y - target.transform.position.y,transform.position.x - target.transform.position.x)*Mathf.Rad2Deg-90;
		transform.eulerAngles = (new Vector3(0,0,orientation));
		rigidbody2D.velocity =  new Vector2(vel*Mathf.Cos((orientation-90)*Mathf.Deg2Rad),
		                                    vel*Mathf.Sin((orientation-90)*Mathf.Deg2Rad)) *20* Time.deltaTime;
		//rigidbody2D.AddForce(transform.right*vel*10000);

		//float angle = Mathf.Atan2(transform.position.x - target.x, transform.position.y - target.y)* Mathf.Rad2Deg - 90;
	//transform.eulerAngles = new Vector3(0, 0, angle);
//	transform.rotation = Quaternion.LookRotation(v, new Vector3(0,0,-1));

						
}


	/*void OnTriggerEnter2D(Collider2D other){

		//Debug.Log ((targetLayer.value & (1<<other.gameObject.layer))!=0);
	//	Debug.Log (other.gameObject.layer);
		if ((targetLayer.value & (1<<other.gameObject.layer))!=0) {

			//if (other.gameObject.layer.==targetLayer.) {
			Health h = other.GetComponent<Health>();
			if(h != null)
				h.Damage(1f);

			Destroy(gameObject);
			//(mask.value & (1 << obj.layer)) > 0

		//}

	}

	}*/

}
