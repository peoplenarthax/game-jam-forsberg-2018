using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject ObjectToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ObjectToFollow != null){
            this.transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, transform.position.z);  ;
        }
	}
}
