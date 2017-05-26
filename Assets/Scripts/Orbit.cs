using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform orbitAround;

    [Tooltip("In minutes")]
    public float dayCycle = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(orbitAround.position, Vector3.up, (360 * Time.deltaTime) / (dayCycle * 60));
    }
}
