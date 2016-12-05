using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
	public GameObject[] eyes;
	public GameObject greenBar;
	public GameObject redBar;
	public GameObject deathParticle;
	public GameObject healthCanvas;

	private float maxWidth;
	private float curWidth;
	public float damagePercentage;
	private float convertedDamage;
	private float savedHeight;
	private bool dieOnce = false;

	// Use this for initialization
	void Start () 
	{
		maxWidth = redBar.transform.localScale.x;
		curWidth = maxWidth;
		convertedDamage = (damagePercentage / 100)*maxWidth;
		savedHeight = greenBar.transform.localScale.y;
	}
	
	// Update is called once per frame
	public void applyDamage (float damageAmount) 
	{
		if (curWidth != 0) 
		{
			if (curWidth - damageAmount >= 0) 
			{
				curWidth -= damageAmount;
				greenBar.transform.localScale = new Vector3 (curWidth, savedHeight, greenBar.transform.localScale.z);
			}
			if (curWidth <= 0.1f) 
			{
				curWidth = 0;
			}
		} 
	}

	void OnTriggerStay(Collider Entered)
	{
		if (Entered.tag == "Weapon") 
		{
			applyDamage (convertedDamage);
			Destroy (Entered.gameObject);
		}
	}

	void Update()
	{
		if (curWidth == 0 && dieOnce == false) 
		{
			dieOnce = true;

			//spawn particle
			GameObject tempParticle = Instantiate(deathParticle, transform.position, transform.rotation, gameObject.transform) as GameObject;
			tempParticle.transform.Rotate (-90, 0, 0);
			tempParticle.transform.lossyScale.Set(1,1,1);
			foreach (GameObject eye in eyes) 
			{
				eye.GetComponent<MeshRenderer> ().enabled = false;
			}
			Destroy (healthCanvas.gameObject);
		}
	}
}
