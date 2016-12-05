using UnityEngine;
using System.Collections;

public class PlayerCommands : MonoBehaviour 
{
	public float AimSpeed;
	public float turnSpeed;

	public KeyCode fireKey;
	public KeyCode leftkey;
	public KeyCode rightkey;

	public GameObject hydraBodyParent;
	public GameObject ikTargetHead;
	public GameObject ikTargetMiddle;
	public GameObject neckBase;


	public GameObject tongueBaseObject;
	public GameObject flameThrowerObject;

	private float ikLeftLimit;
	private float ikRightLimit;



	void Start()
	{
		float value = ikTargetHead.transform.parent.lossyScale.x/2;
		ikLeftLimit = (ikTargetHead.transform.position.x) - value;
		ikRightLimit = (ikTargetHead.transform.position.x) + value;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (fireKey) && GameObject.Find("1FT") == null) 
		{
			GameObject FlameThrower = Instantiate (flameThrowerObject, tongueBaseObject.transform.position, gameObject.transform.rotation, tongueBaseObject.transform) as GameObject;
			FlameThrower.name = "1FT";
			FlameThrower.transform.Rotate (0, ikTargetHead.transform.eulerAngles.y+180, 0);
			hydraBodyParent.transform.GetComponent<Animation_Hydra> () .AnimateAttack();
		}
			
		if (Input.GetKeyUp (fireKey)) 
		{
			hydraBodyParent.transform.GetComponent<Animation_Hydra> () .AnimateMouthClosed();
		}

		if (Input.GetKey (rightkey) && ikTargetHead.transform.position.x < ikRightLimit) 
		{
			ikTargetHead.transform.Translate (Time.deltaTime*AimSpeed, 0, 0);
			ikTargetHead.transform.Rotate (0,(turnSpeed*Time.deltaTime)/2.5f,0);
			gameObject.transform.RotateAround (neckBase.transform.position , new Vector3(0,1,0), turnSpeed*Time.deltaTime);

			ikTargetMiddle.transform.Translate ((Time.deltaTime*AimSpeed)/3f, 0, 0);

		}
		if (Input.GetKey (leftkey) && ikTargetHead.transform.position.x > ikLeftLimit) 
		{
			ikTargetHead.transform.Translate (-Time.deltaTime*AimSpeed, 0, 0);
			ikTargetHead.transform.Rotate (0,(turnSpeed*-Time.deltaTime)/2.5f,0);
			gameObject.transform.RotateAround (neckBase.transform.position , new Vector3(0,1,0), turnSpeed*-Time.deltaTime);

			ikTargetMiddle.transform.Translate ((-Time.deltaTime*AimSpeed)/3f, 0, 0);
		}

	}
}
