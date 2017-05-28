using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    public float moveSpeed = 10f;
    public float verticalMouseSensitivity = 100f;
    public float horizontalMouseSensitivity = 100f;
    public float jumpHeight = 20f;
    public float distToGround = 2f;

    Vector3 moveDirection;
    float verticalLookRotation;

    private Camera cam;


	// Use this for initialization
	new void Start () {
        base.Start();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        cam = gameObject.GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate to face upwards
        Vector3 planetOrientation = (transform.position - gm.getActivePlanet().transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(transform.up, planetOrientation) * transform.rotation;

        Vector3 inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        moveDirection = inputVelocity * moveSpeed;

        verticalLookRotation += Input.GetAxis("Mouse Y") * verticalMouseSensitivity * Time.deltaTime;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cam.transform.localEulerAngles = Vector3.left * verticalLookRotation;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * horizontalMouseSensitivity * Time.deltaTime);
	}

    private new void FixedUpdate()
    {
        base.FixedUpdate();

        rb.MovePosition(transform.position + transform.TransformDirection(moveDirection) * Time.fixedDeltaTime);
        if (Input.GetKeyDown("space") && onGround())
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private bool onGround()
    {
        return Physics.Raycast(transform.position, -transform.up, distToGround + 0.1f);
    }

    public Inventory GetInventory()
    {
        return gameObject.GetComponent<Inventory>();
    }
}
