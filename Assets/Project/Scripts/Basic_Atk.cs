using UnityEngine;
using System.Collections;

public class Basic_Atk : MonoBehaviour {
	public enum Atk_Type{ Ranged, Melee}

	public Transform arrowPrefab;
	public Transform hand;
	public float arrowDelay=0.4f;
	public GameObject targetHit;
	public Atk_Type atktype;
	private float time;
	public float atkspeed;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void action(Vector3 target,LayerMask LM, bool lookRight ){
	

		if( time > 0)
		{
			time -= Time.deltaTime;
		}
		else 
		{
			time = atkspeed;
			animator.SetTrigger("attack");

			//valida o tipo de ataque que e, ranged ou melee
			if(atktype==Atk_Type.Ranged){

				StartCoroutine(makeArrow(arrowDelay,targetHit,LM,lookRight));
			}
			else if(atktype==Atk_Type.Melee){
				gameObject.GetComponent<HitDamage>().target=targetHit;
				gameObject.GetComponent<HitDamage>().targetLayer = LM;
				gameObject.GetComponent<HitDamage>().trigger = true;
				gameObject.GetComponent<HitDamage>().melee = true;
			}
		}


}


	IEnumerator makeArrow(float delay,GameObject enemytarget,LayerMask LM, bool lookRight)
	{
		yield return new WaitForSeconds(delay);
		var go = Instantiate(arrowPrefab, hand.position, Quaternion.identity) as Transform;
		go.GetComponent<HitDamage> ().targetLayer = LM;
		go.GetComponent<Arrow> ().target = enemytarget;
		go.GetComponent<Arrow> ().lookRight = lookRight;
		go.GetComponent<HitDamage>().target=targetHit;
		go.GetComponent<HitDamage>().melee = false;
	}

}
