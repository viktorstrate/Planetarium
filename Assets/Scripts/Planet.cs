using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public float gravity = 1000f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyGravity(Rigidbody rb, Transform entityTrans)
    {
        Vector3 force = transform.position - entityTrans.position;
        force.Normalize();
        rb.AddForce(force * gravity / Vector3.Distance(transform.position, entityTrans.position));
    }
}
