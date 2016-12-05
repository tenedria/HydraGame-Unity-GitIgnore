using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour 
{
	public GameObject enemy;
	private Vector3 RandomizedSpawn;
	private Vector3 currentVector;
	private float minWidth;
	private float maxWidth;
	private float minHeight;
	private float maxHeight;


	public int EnemyPerWave;
	private int enemyCount;

	public void RandomizeSpawn()
	{
		currentVector = gameObject.transform.position;
		float width = gameObject.transform.lossyScale.x;
		minWidth = currentVector.x - (width / 2);
		maxWidth = currentVector.x + (width / 2);
		float height = gameObject.transform.lossyScale.z;
		minHeight = currentVector.z - (height / 2);
		maxHeight = currentVector.z + (height / 2);

		enemyCount = 0;
		while (enemyCount < EnemyPerWave) 
		{
			RandomizedSpawn = new Vector3 (Random.Range (minWidth, maxWidth), gameObject.transform.lossyScale.y, Random.Range (minHeight, maxHeight));		//spawn an enemy
			Instantiate (enemy.gameObject, RandomizedSpawn, transform.rotation);
			enemyCount++;
		}
	}
}
