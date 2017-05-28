using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Gatherer : MonoBehaviour {

    public float range = 10f;
    public GameObject gunTip;

    public GameObject particles;

    public float firerate = 3;
    public float damage = 2;

    GameManager gm;
    LineRenderer lineRenderer;
    bool gatheringResources = false;
    Camera cam;

    private Light targetLight;
    private Light tipLight;
    private RaycastHit lastHit;
    private float lastShot;

    TerrainObject target;

	// Use this for initialization
	void Start () {
        gm = GameManager.getGameManager();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        cam = Camera.main;

        GameObject targetLightGO = new GameObject("Target Light");

        targetLight = targetLightGO.AddComponent<Light>();
        targetLight.type = LightType.Point;
        targetLight.enabled = false;

        targetLight.transform.SetParent(transform);

        particles = Instantiate(particles);
        particles.SetActive(false);

        tipLight = gunTip.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        gatheringResources = false;
        if (Input.GetButton("Fire"))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward);
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                TerrainObject obj = hit.transform.gameObject.GetComponentInParent<TerrainObject>();
                obj = obj ?? hit.transform.gameObject.GetComponent<TerrainObject>();
                if (obj != null)
                {
                    RaycastHit newHit;
                    if(Physics.Raycast(cam.transform.position, (obj.origin.position - cam.transform.position), out newHit, LayerMask.NameToLayer("TerrainObject")))
                    {
                        lastHit = newHit;

                        gatheringResources = true;
                        target = obj;
                        shoot(true);
                    }
                    
                }               
            }
        }

        if (!gatheringResources)
        {
            shoot(false);
        }

    }

    // Should be called once pr Update()
    void shoot(bool shoot)
    {
        // Visuals
        if (shoot)
        {
            lineRenderer.SetPosition(0, gunTip.transform.position);
            lineRenderer.SetPosition(1, target.origin.position);

            targetLight.transform.position = lastHit.point;

            particles.transform.position = lastHit.point;
        }

        lineRenderer.enabled = shoot;
        targetLight.enabled = shoot;
        tipLight.enabled = shoot;
        lineRenderer.enabled = shoot;
        particles.SetActive(shoot);

        // Gather object
        if (shoot)
        {
            if (lastShot + (1/firerate) < Time.time)
            {
                lastShot = Time.time;
                target.Attack(damage);
            }
        } else
        {
            lastShot = Time.time;
        }
        
    }
}
