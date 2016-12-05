using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour 
{
	public GameObject greenHealthBar;
	public GameObject redHealthBar;
    public float maxHealth;
	private float curHealth;

	void Start()
	{
		curHealth = maxHealth;
	}


    public void OnDamageTaken(float damageAmount)
    {
		if (curHealth - damageAmount >= 0) 
		{
			curHealth -= damageAmount;
			float newWidth = greenHealthBar.transform.localScale.x -((damageAmount / maxHealth) * redHealthBar.transform.localScale.x);
			Debug.Log ("attempt to change health:"+ newWidth);
			greenHealthBar.transform.localScale = new Vector3 (newWidth, greenHealthBar.transform.localScale.z, greenHealthBar.transform.localScale.z);		
		}

        else if (curHealth <= 0)
        {
			//player is dead
			Debug.Log("player is dead");
        }

    }

}
