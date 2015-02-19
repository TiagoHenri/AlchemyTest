using UnityEngine;
using System.Collections;

public class MovementBasic : MonoBehaviour {

	public GameObject enemyHero;
	private string tag;
	public float range=5f;
	public LayerMask LM;
	public Transform enemy;
	public Vector3 targetPosition;
	public float speed=5;
	public bool lookRight = true;
	private Animator animator;
	private Basic_Atk atk;
	public bool stopmove = false;

	//HitDamage HD = gameObject.GetComponent<Basic_Atk>;

	private Vector3 closest_enemy;
	private float time=0f;


	void Start () {
		atk = GetComponent<Basic_Atk>();
		targetPosition = transform.position;
		animator = GetComponent<Animator>();
		enemy=enemyHero.transform;


		//enemy.GetComponent <>
		//enemyHero = GameObject.FindGameObjectWithTag(tag).transform;
	}
	

	void FixedUpdate () {

		Debug.DrawLine(new Vector3(transform.position.x - range,transform.position.y,0.0f), new Vector3(transform.position.x + range,transform.position.y  ,0.0f), Color.green);
		Debug.DrawLine(new Vector3(transform.position.x,transform.position.y - range,0.0f), new Vector3(transform.position.x,transform.position.y + range,0.0f), Color.green);
		Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, range, LM);

		if(hit.Length >0)
		{
			stopmove = true;

			enemy=hit[0].gameObject.transform;
			gameObject.GetComponent<Basic_Atk>().targetHit = hit[0].gameObject; 
			//Debug.Log("achei algo");

		}
		else
		{
			//Debug.Log("nada perto");
			stopmove = false;
			if(!enemy){
				enemy=enemyHero.transform;
				gameObject.GetComponent<Basic_Atk>().targetHit = enemyHero;

			}

		}

		/*
		if (Front_hit.collider == null) {
			stopmove_F = false;
			
		} else {
			stopmove_F = true;
			closest_enemy=Front_hit.transform.position;
		}*/

		/*
		//RaycastHit2D Front_hit = Physics2D.Raycast (transform.position, Vector2.right, range, LM);
		//collider2D[] Front_hit = Physics2D.OverlapCircleAll(transform.position, 2f, LM);


		if (Front_hit.collider == null) {
			stopmove_F = false;
			
		} else {
			stopmove_F = true;
			closest_enemy=Front_hit.transform.position;
		}

		//RaycastHit2D Back_hit = Physics2D.Raycast (transform.position, -Vector2.right, range, LM);
		RaycastHit2D Back_hit = Physics2D.OverlapCircle(transform.position, 2f, LM);
		if (Back_hit.collider == null) {
			stopmove_B = false;
			
		} else {
			stopmove_B = true;
			closest_enemy=Back_hit.transform.position;
		}
		*/

		targetPosition = enemy.position;

		if (!stopmove) {
			
			
			if (targetPosition.x > transform.position.x && !lookRight)
				Flip ();
			if (targetPosition.x < transform.position.x && lookRight)
				Flip ();
			
			var p = transform.position;
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
			
			animator.SetFloat ("speed", (transform.position - p).magnitude / Time.deltaTime);
			
		} else {
			animator.SetFloat ("speed",0);

			if( time > 0)
			{
				time -= Time.deltaTime;
			}
			else 
			{

				if (targetPosition.x > transform.position.x && !lookRight)
					Flip ();
				if (targetPosition.x < transform.position.x && lookRight)
					Flip ();
				atk.action(targetPosition,LM,lookRight);
			}
			
			
		}
		
	}
	
	void Update () {
		


		/*if(Input.GetMouseButtonDown(1))
		{
			if(Random.Range(0f, 1.0f) > 0.5f)
				animator.SetTrigger("attack");
			else
				animator.SetTrigger("special");
			StartCoroutine(makeArrow(arrowDelay, lookRight));
		}*/
	}
	
	
	public void Flip()
	{
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
		lookRight = !lookRight;
	}
	
	
}