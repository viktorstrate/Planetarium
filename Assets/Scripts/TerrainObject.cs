using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObject : MonoBehaviour {

    public Transform origin;
    public GameObject drop;
    public int maxDrops = 4;
    public int minDrops = 1;
    [Tooltip("How hard it is to gather")]
    public float life = 10f;
    public float dropRange = 2f;

	// Use this for initialization
	void Start () {
        if (origin == null) origin = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Attack the object, if life drops below 0, the object will get destroyed
    public void Attack (float dmg)
    {
        life -= dmg;

        if(life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        life = 0;
        if (drop != null)
        {
            int amount = Mathf.FloorToInt(Random.value * (maxDrops - minDrops) + minDrops);
            for (int i = 0; i < amount; i++)
            {
                GameObject go = Instantiate(drop, transform.parent);
                go.transform.position = transform.position + new Vector3(Random.value*dropRange, Random.value * dropRange, Random.value * dropRange);
            }
        }
        
        Destroy(gameObject);
    }
}
