using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public Canvas uiCanvas;
    private Camera uiCamera;

	// Use this for initialization
	void Start () {
        
        uiCamera = transform.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        /*RectTransform rectTrans = uiCanvas.GetComponent<RectTransform>();
        rectTrans.
        uiRect.width = uiCamera.orthographicSize * 2;
        uiRect.height = uiCamera.orthographicSize * 2 * uiCamera.aspect;*/
        Debug.Log(uiCamera.orthographicSize * 2);

    }
}
