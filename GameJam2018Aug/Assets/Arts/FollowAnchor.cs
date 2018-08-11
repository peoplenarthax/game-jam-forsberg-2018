using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAnchor : MonoBehaviour {

	public GameObject anchor;

	void Update () 
	{
		transform.position = anchor.transform.position;
	}
}
