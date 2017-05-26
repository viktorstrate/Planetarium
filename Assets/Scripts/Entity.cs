using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    
    protected Rigidbody rb;
    protected GameManager gm;

    // Use this for initialization
    public void Start() {
        gm = GameManager.getGameManager();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void FixedUpdate()
    {
        foreach(Planet p in gm.getPlanets())
        {
            applyGravity(p);
        }

    }

    private void applyGravity(Planet planet)
    {
        planet.ApplyGravity(rb, transform);
    }
}
