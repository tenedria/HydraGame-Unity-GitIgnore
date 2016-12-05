using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour 
{
	public float movementSpeed;
	private GameObject player;
	public GameObject lookAtGameobject;
	private float yRotationDifference;
	public float rotationBuffer;
	private bool reachedTargetRotation;
	public float rotationSpeed;
	public GameObject explosionParticles;

	public float damageToPlayer;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Use this for initialization
	void OnTriggerEnter (Collider Entered) 
	{
		if (Entered.tag == "Player") 
		{
			//explosion particles
			Instantiate (explosionParticles, transform.position, transform.rotation);
			//damage player
			player.GetComponent<Health>().OnDamageTaken(damageToPlayer);
			//destroy this object
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		rotateToTargetRotation (player.transform.position);
		transform.Translate (0,0, movementSpeed*Time.deltaTime);
	}


	//makes the character rotates towards a specific target
	void rotateToTargetRotation(Vector3 PositiontoTarget)
	{
		lookAtGameobject.transform.LookAt(PositiontoTarget);

		float lookatY = lookAtGameobject.transform.eulerAngles.y;
		float goY = gameObject.transform.eulerAngles.y;

		//checks how close the rotation is to the goal rotation
		if (lookatY > goY)
		{
			yRotationDifference = lookatY - goY;
		}
		if (lookatY < goY)
		{
			yRotationDifference = goY - lookatY;
		}

		//rotates towards the target
		if (goY != lookatY && yRotationDifference > rotationBuffer)
		{
			reachedTargetRotation = false;

			if (goY > lookatY)
			{
				if ((goY - lookatY) < 180) 
				{
					transform.Rotate (0, -Time.deltaTime * rotationSpeed, 0);
				}
				else 
				{
					transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
				}
			}
			if (goY < lookatY)
			{
				if ((lookatY - goY) < 180) 
				{
					transform.Rotate (0, Time.deltaTime * rotationSpeed, 0);
				}
				else 
				{
					transform.Rotate (0, -Time.deltaTime * rotationSpeed, 0);
				}
			}
		}
		else if (reachedTargetRotation == false)
		{
			//Debug.Log("Aquired Target");
			reachedTargetRotation = true;
		}
	}
}
