using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour {
    public bool picked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("I hit something: " + collider.gameObject.name);
        if (collider.gameObject.GetComponent<Pickable>() != null)
        {
            collider.gameObject.transform.SetParent(this.transform);
            picked = true;
        }
    }
}
