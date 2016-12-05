using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelWaves : MonoBehaviour 
{
	public GameObject player;
	public GameObject WaveNumber;
	public GameObject levelMessage;
	public GameObject waveSpawner;

	public int amountOfLevels;
	public float distancePerLevels;
	public float movementSpeed;
	private float curDistance;
	private float objDistance;
	public int curLevel;
	private bool reachedLevel = true;
	private bool startAnimationOnce = false;


	public float curTimer;
	public float maxTimer;

	void Timer()
	{
		if(startTimer == true)
		{
			if (curTimer < maxTimer) 
			{
				curTimer += Time.deltaTime;
			} 
			else
			{
				startTimer = false;
			}
		}

		if (startTimer == false)
		{
			levelMessage.SetActive (false);
			reachedLevel = false;
		}
	}

	//function to move the hydra after each wave is completed and animate the walk
	void moveToNextLevel()
	{
			curDistance = player.transform.position.z;
			objDistance = curLevel * distancePerLevels;

			
			if (curDistance < objDistance) 
			{
				player.transform.Translate (0, 0, -movementSpeed*Time.deltaTime);
				if (startAnimationOnce == false) 
				{
					player.GetComponent<Animation_Hydra> ().AnimateWalk ();
					startAnimationOnce = true;
				}
			} 
			else if(curLevel < amountOfLevels)
			{
				curLevel++;
				WaveNumber.GetComponent<Text>().text = "Now Playing Level: " + curLevel;
				reachedLevel = true;
				player.GetComponent<Animation_Hydra> ().AnimateIdle ();
				startAnimationOnce = false;
			}
	}


	// Use this for initialization
	void Start () 
	{
		curLevel = 0;
		WaveNumber.GetComponent<Text>().text = "Now Playing Level: " + curLevel;
	}

	private bool startTimer = true;

	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Enemy") == null && levelMessage.activeSelf == false) 
		{
			levelMessage.SetActive (true);
			startTimer = true;
			curTimer = 0;
			waveSpawner.transform.GetComponent<EnemySpawn> () .RandomizeSpawn();
		}	

		if (reachedLevel == false) 
		{
			moveToNextLevel();
		}

		if (startTimer == true) 
		{
			Timer ();
		}

	}
}
