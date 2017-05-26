using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private Light[] directionalLights;
    private Light[] pointLights;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameManager.getGameManager();

        Light[] lights = GetComponentsInChildren<Light>();
        int countDirectional = 0;
        int countPoint = 0;

        foreach(Light l in lights)
        {
            switch (l.type)
            {
                case LightType.Directional:
                    countDirectional++;
                    break;
                case LightType.Point:
                    countPoint++;
                    break;
            }
        }

        directionalLights = new Light[countDirectional];
        pointLights = new Light[countPoint];

        countDirectional = countPoint = 0;

        foreach(Light l in lights)
        {
            switch (l.type)
            {
                case LightType.Directional:
                    directionalLights[countDirectional] = l;
                    countDirectional++;
                    break;
                case LightType.Point:
                    pointLights[countPoint] = l;
                    countPoint++;
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction = gm.getActivePlanet().transform.position - transform.position;

        foreach (Light dir in directionalLights)
        {

            dir.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
	}
}
