using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Camera UICamera;
    public Player player;

    InventorySlot[] hotbar;
    GameObject[] hotbarHolder;
    GameObject hotbarHolderPivot;

    public float hotbarPadding = 1;

	// Use this for initialization
	void Start () {
        hotbar = new InventorySlot[8];
        hotbarHolder = new GameObject[8];

        hotbarHolderPivot = new GameObject();
        hotbarHolderPivot.name = "Hotbar Pivot";
        hotbarHolderPivot.transform.parent = UICamera.transform;
        UpdateHotbarPivot();

        for (int i = 0; i < hotbar.Length; i++)
        {
            GameObject temp = new GameObject();
            temp.transform.position = hotbarHolderPivot.transform.position + new Vector3((i*2), 0);
            temp.transform.parent = hotbarHolderPivot.transform;
            temp.name = "Hotbar Item " + i;
            hotbarHolder[i] = temp;
        }

        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHotbarPivot();
	}

    void UpdateHotbarPivot()
    {
        hotbarHolderPivot.transform.position = UICamera.transform.position + new Vector3(-UICamera.orthographicSize*UICamera.aspect + hotbarPadding, -UICamera.orthographicSize + hotbarPadding, 5);
    }

    public void AddItem(Pickup pickup, int amount)
    {
        InventoryItem item = pickup.item;
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (hotbar[i].item.id == item.id)
            {
                hotbar[i].amount += amount;
            }
            else if (hotbar[i].amount <= 0)
            {
                hotbar[i].item = item;
                hotbar[i].amount = amount;

                GameObject goItem = Instantiate(pickup.gameObject);
                goItem.transform.parent = hotbarHolder[i].transform;
                goItem.transform.position = hotbarHolder[i].transform.position;
                goItem.transform.rotation = Quaternion.identity;
                Destroy(goItem.GetComponent<Rigidbody>());

                Component[] comps = goItem.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour comp in comps)
                {
                    comp.enabled = false;
                }
                
                return;
            }
        }
    }
}
