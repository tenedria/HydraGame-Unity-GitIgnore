using UnityEngine;
using System.Collections;

public class DeathParticle : MonoBehaviour 
{
	public float despawnTime;
	private float curTime;
	
	// Update is called once per frame
	void Update () 
	{
		if (curTime < despawnTime) 
		{
			curTime += Time.deltaTime;
		} 
		else 
		{
			Destroy (gameObject.transform.parent.gameObject.transform.parent.gameObject);
		}
	}
}
