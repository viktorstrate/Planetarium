using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected Planet planet;
    protected Rigidbody rb;

	// Use this for initialization
	public void Start () {
        Debug.Log("Entity");
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<Planet>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void FixedUpdate()
    {
        planet.ApplyForce(rb, transform);
    }
}
