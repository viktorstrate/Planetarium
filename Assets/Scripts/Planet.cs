using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public float gravity = 1000f;
    private GameManager gm;

    // Use this for initialization
    void Start () {
        gm = GameManager.getGameManager();
        gameObject.layer = LayerMask.NameToLayer("ActivePlanet");
        
        if (gameObject.GetInstanceID() == gm.getActivePlanet().gameObject.GetInstanceID())
            SetPlanetLayer("ActivePlanet");
        else SetPlanetLayer("InactivePlanet");
    }
	
	// Update is called once per frame
	void Update () {
	}

    void SetPlanetLayer(string layer)
    {
        _SetPlanetLayerRecursively(gameObject, LayerMask.NameToLayer(layer));
    }

    private void _SetPlanetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach(Transform child in obj.transform)
        {
            _SetPlanetLayerRecursively(child.gameObject, layer);
        }
    }

    public void ApplyGravity(Rigidbody rb, Transform entityTrans)
    {
        Vector3 force = transform.position - entityTrans.position;
        force.Normalize();
        rb.AddForce(force * gravity / Vector3.Distance(transform.position, entityTrans.position));
    }
}
