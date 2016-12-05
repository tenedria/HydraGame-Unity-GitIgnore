using UnityEngine;
using System.Collections;

public class ExplosionDespawner : MonoBehaviour 
{
	public float TimeToDespawn;
	private float curTime = 0;
	
	// Update is called once per frame
	void Update () 
	{
		if (curTime < TimeToDespawn) 
		{
			curTime += Time.deltaTime;
		} 
		else 
		{
			Destroy (gameObject);
		}
	}
}
