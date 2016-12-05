using UnityEngine;
using System.Collections;

public class flamethrower : MonoBehaviour 
{
	public float damageRate;
	public float fadeSpeed;
	public float fadeTime;

	// Use this for initialization
	void OnTriggerStay (Collider entered) 
	{
		if (entered.tag == "Enemy") 
		{
			entered.GetComponent<EnemyHealth> ().applyDamage(damageRate/10 * Time.deltaTime);
		}
	}

	private float curTime;
	// Update is called once per frame
	void Update () 
	{
		curTime++;
		if (curTime < fadeTime) {
			gameObject.GetComponent<Light> ().intensity += fadeSpeed * Time.deltaTime;
		} 
		else 
		{
			gameObject.GetComponent<Light> ().intensity -= fadeSpeed * Time.deltaTime;
		}
	}
}
