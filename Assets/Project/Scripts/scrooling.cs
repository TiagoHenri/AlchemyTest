using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class scrooling : MonoBehaviour {

	public Vector2 speed = new Vector2(1,1);
	public Vector2 direction = new Vector2(-1,0);

	public float parallaxX = 0;
	public float parallaxY = 0;
	public bool prallaxControl = false;

	public bool islooping = false;
	private List<Transform> backgrounpPart;

	void Start()
	{
		if(islooping)
		{
			backgrounpPart = new List<Transform>();

			for(int i= 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);

				if(child.renderer != null)
				{
					backgrounpPart.Add (child);
				}
				backgrounpPart.OrderBy(t => t.position.x).ToList();
			}
		}
	}

	void Update()
	{
		Vector2 movement = new Vector2(
							direction.x * speed.x,
							direction.y * speed.y
							);

		movement *= Time.deltaTime;	
		transform.Translate(movement);

		if(islooping)
		{
			Transform firstChild = backgrounpPart.FirstOrDefault();

			if(firstChild != null)
			{

				if(firstChild.position.x < Camera.main.transform.position.x)
				{

					if(!firstChild.renderer.isVisibleFrom(Camera.main))
					{
						Transform lastChild = backgrounpPart.LastOrDefault();

						Vector3 lastPosition = lastChild.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

						firstChild.position = new Vector3(
												lastPosition.x + lastSize.x,
												firstChild.position.y,
												firstChild.position.z);

						if(prallaxControl)
						{
							firstChild.position = new Vector3(
								//lastPosition.x + lastSize.x,
								lastPosition.x + parallaxX,
								firstChild.position.y + parallaxY,
								firstChild.position.z);

						}

						backgrounpPart.Remove(firstChild);
						backgrounpPart.Add(firstChild);
					}
				}
			}
		}
	}
}
