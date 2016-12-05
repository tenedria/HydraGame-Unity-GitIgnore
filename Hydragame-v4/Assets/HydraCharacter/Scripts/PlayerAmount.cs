using UnityEngine;
using System.Collections;

public class PlayerAmount : MonoBehaviour 
{
	public int numberOfPlayers;

	public GameObject head1;
	public GameObject head2;
	public GameObject head3;
	// Use this for initialization
	void Start () 
	{
		if (numberOfPlayers <= 1) 
		{
			head2.SetActive (false);
			head3.SetActive (false);
		}
		if (numberOfPlayers == 2) 
		{
			head1.SetActive (false);
		}
		if (numberOfPlayers >= 3) 
		{
			//do nothing
		}
	}
}
