using UnityEngine;
using System.Collections;

public class GoblinAnim : MonoBehaviour 
{
	public GameObject Jaw;
	public float jawMovements;
	public float jawSpeed;
	private bool goingDownJaw = true;
	private float maxHeightJaw;

	public GameObject Head;
	public float headMovements;
	public float headSpeed;
	private bool goingDownHead = true;
	private float maxHeightHead;

	public GameObject Body;
	public float bodyMovements;
	public float bodySpeed;
	private bool goingDownBody = true;
	private float maxHeightBody;


	private float minHeight;
	private float curHeight;

	// Use this for initialization
	void Start () 
	{
		maxHeightJaw = Jaw.transform.position.y;
		maxHeightHead = Head.transform.position.y;
		maxHeightBody = Body.transform.position.y;

	}

	void moveObject(GameObject movethis, float byThisAmount, float thisFast, float maxHeight, bool goingDown)
	{
		minHeight = maxHeight - byThisAmount;
		curHeight = movethis.transform.position.y;

		if (goingDown) 
		{
				movethis.transform.Translate (0, -thisFast * Time.deltaTime, 0);
				curHeight-=(thisFast*Time.deltaTime);
		} 

		else 
		{
				movethis.transform.Translate (0, thisFast * Time.deltaTime, 0);
				curHeight += (thisFast*Time.deltaTime);
		}
	}

	void rotateObject(GameObject rotatethis, float byThisAmount, float thisFast, float maxRotation, bool RotationLowering)
	{
		if (RotationLowering) 
		{
			rotatethis.transform.Rotate (-thisFast * Time.deltaTime,0,0);
		}
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Jaw.transform.position.y < (maxHeightJaw - jawMovements)) 
		{
			goingDownJaw = false;
		}
		else if (Jaw.transform.position.y >= maxHeightJaw) 
		{
			goingDownJaw = true;
		}

		if (Head.transform.position.y < (maxHeightHead - headMovements)) 
		{
			goingDownHead = false;
		}
		else if (Head.transform.position.y >= maxHeightHead) 
		{
			goingDownHead = true;
		}

		if (Body.transform.position.y < (maxHeightBody - bodyMovements)) 
		{
			goingDownBody = false;
		}
		else if (Body.transform.position.y >= maxHeightBody) 
		{
			goingDownBody = true;
		}

		moveObject (Body, bodyMovements, bodySpeed, maxHeightBody, goingDownBody);
		moveObject (Jaw, jawMovements, jawSpeed, maxHeightJaw, goingDownJaw);
		moveObject (Head, headMovements, headSpeed, maxHeightHead, goingDownHead);
	}
}
