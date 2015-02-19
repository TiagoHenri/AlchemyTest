using UnityEngine;
using System.Collections;

//script responsavel por computar o dano recebido e destruir o gameobject caso o life acabe
public class Health : MonoBehaviour {
	
	public float hp = 5f;
	public float timeBlink = 0.01f;
	public bool getHit = false;


	public void Damage(float damage)
	{

		SpriteRenderer[] s = transform.GetComponentsInChildren<SpriteRenderer>();

		foreach(SpriteRenderer sp in s)
		{
			sp.color = Color.red;
		}

		hp -= damage;

		if(hp < 1)
		{
			destroy();
		}

		StartCoroutine(color(s));

		//transform.GetComponentInChildren<SpriteRenderer>().color = Color.white;
	
	}

	private void destroy()
	{
		Destroy(gameObject);

	}

	IEnumerator color(SpriteRenderer[] ps)
	{
		yield return new WaitForSeconds(timeBlink);
		foreach(SpriteRenderer sp in ps)
		{
			sp.color = Color.white;
		}
	}
}
