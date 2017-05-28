using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public const float RANGE = 6;
    private GameManager gm;
    private Rigidbody rb;
    public InventoryItem item;

	// Use this for initialization
	void Start () {
        gm = GameManager.getGameManager();
        rb = transform.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = gm.getPlayer().transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);
        if (distance < RANGE)
        {
            rb.AddForce((playerPos - transform.position) * 25 / (distance + 1));
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = gm.getPlayer().gameObject;
        if (collision.transform.GetInstanceID() == player.transform.GetInstanceID())
        {
            PickupItem();
        }
    }

    void PickupItem()
    {
        Player player = gm.getPlayer();
        player.GetInventory().AddItem(this, 1);
        Destroy(gameObject);
    }
}
