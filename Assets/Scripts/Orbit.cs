using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform orbitAround;
    public Vector3 localAxis;

    [Tooltip("In minutes")]
    public float day = 10;

    [Tooltip("In minutes")]
    public float year = 60;

    // Use this for initialization
    void Start () {
        localAxis.Normalize();
	}
	
	void FixedUpdate () {
        Quaternion oldRotation = transform.rotation;
        transform.RotateAround(orbitAround.position, Vector3.up, (360 * Time.deltaTime) / (year * 60));
        transform.rotation = oldRotation * Quaternion.Euler(localAxis * 360 / (60 * day) * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 axis = localAxis.normalized;
        float size = 500f;
        Gizmos.color = Color.white;
        Gizmos.DrawLine(-axis * size + transform.position, axis * size + transform.position);
    }
}
