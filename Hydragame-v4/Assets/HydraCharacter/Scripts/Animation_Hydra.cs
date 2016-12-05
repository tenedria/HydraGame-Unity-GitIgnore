using UnityEngine;
using System.Collections;

public class Animation_Hydra : MonoBehaviour 
{
	//gameobjects
	public GameObject headtop;
	public GameObject headLeft;
	public GameObject headRight;
	public GameObject body;

	//fix renderingbug
	public GameObject GOwalkbody;
	public GameObject GOidlebody;

	//animations
	public AnimationClip idleBody;
	public AnimationClip walkBody;
	public AnimationClip attackBody;
	public AnimationClip idleHead;
	public AnimationClip walkHead;
	public AnimationClip attackHead;
	public AnimationClip closemouthHead;


	[Header("do not blend from walking to attack, put idle inbetween")]
	//time of blending
	public float blendTime;

	// function to play all animations (need animation to work)
	void PlayAnimation (string animationHead, string animationBody) 
	{
		//body
		body.GetComponent<Animation> ().CrossFade (animationBody, blendTime);

		//heads
		headtop.GetComponent<Animation> ().CrossFade (animationHead, blendTime);
		headRight.GetComponent<Animation> ().CrossFade (animationHead, blendTime);
		headLeft.GetComponent<Animation> ().CrossFade (animationHead, blendTime);
	}

	public void AnimateWalk()
	{		
		GameObject tempBody = Instantiate (GOwalkbody, body.transform.position, body.transform.rotation) as GameObject;
		tempBody.transform.SetParent (gameObject.transform);
		Destroy (body.gameObject);
		body = tempBody;
		PlayAnimation (walkHead.name, walkBody.name);

	}

	public void AnimateAttack()
	{
		GameObject tempBody = Instantiate (GOidlebody, body.transform.position, body.transform.rotation) as GameObject;
		tempBody.transform.SetParent (gameObject.transform);
		Destroy (body.gameObject);
		body = tempBody;
		PlayAnimation (attackHead.name, attackBody.name);
	}

	public void AnimateMouthClosed()
	{
		GameObject tempBody = Instantiate (GOidlebody, body.transform.position, body.transform.rotation) as GameObject;
		tempBody.transform.SetParent (gameObject.transform);
		Destroy (body.gameObject);
		body = tempBody;
		PlayAnimation (closemouthHead.name, idleBody.name);
	}

	public void AnimateIdle()
	{
		GameObject tempBody = Instantiate (GOidlebody, body.transform.position, body.transform.rotation) as GameObject;
		tempBody.transform.SetParent (gameObject.transform);
		Destroy (body.gameObject);
		body = tempBody;
		PlayAnimation (idleHead.name, idleBody.name);
	}
}
