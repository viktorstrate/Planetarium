using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    private Light[] directionalLights;
    private Light[] pointLights;

	// Use this for initialization
	void Start () {
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

        Debug.Log("Star: dir " + directionalLights.Length + " point " + pointLights.Length);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
