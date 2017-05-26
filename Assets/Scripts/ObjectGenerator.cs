using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    public GameObject objectToGenerate;
    public int amountMin = 30;
    public int amountMax = 40;
    public float rayRadius = 400f;

	// Use this for initialization
	void Start () {
        int objectAmount = Random.Range(amountMin, amountMax);
        int count = 0;

        while(count <= objectAmount)
        {
            GameObject obj = generateObject();
            if (obj != null) count++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    GameObject generateObject()
    {
        Vector3 origin = new Vector3(Random.value*2-1, Random.value * 2 - 1, Random.value * 2 - 1).normalized * rayRadius;
        Vector3 direction = (transform.position - origin).normalized;

        RaycastHit hitInfo;
        if (Physics.Raycast(origin, direction, out hitInfo, rayRadius))
        {
            if (hitInfo.transform != gameObject.transform) return null;
            GameObject obj = Instantiate(objectToGenerate, hitInfo.point, Quaternion.FromToRotation(transform.up, -direction));
            obj.transform.parent = gameObject.transform;
            return obj;
        }
        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rayRadius);
    }
}
