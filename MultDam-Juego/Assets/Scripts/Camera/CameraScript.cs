using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraScript : MonoBehaviour
{

    public int distance = 10;
    public float zoomPerFrameOnDeleted = 0.25f;
    
    private Camera cam;

    private bool isRemoved = false;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 
            -distance);
    }

    private void FixedUpdate()
    {
        if (isRemoved)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y,
                cam.transform.position.z + zoomPerFrameOnDeleted * Time.fixedDeltaTime);
        }
    }

    public void Remove()
    {
        cam.transform.SetParent(null);
        isRemoved = true;
    }
    
}
