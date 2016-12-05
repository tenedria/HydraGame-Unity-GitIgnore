using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour 
{
	public float movementSpeed;
	public float despawnTime;
	private float curTime = 0;

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0,0,movementSpeed*Time.deltaTime);

		if (curTime < despawnTime) 
		{
			curTime += Time.deltaTime;
		} 
		else 
		{
			//despawn bullet
			Destroy(gameObject);
		}
	}
}
