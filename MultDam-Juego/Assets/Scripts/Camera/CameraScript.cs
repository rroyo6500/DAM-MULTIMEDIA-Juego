using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraScript : MonoBehaviour
{
    
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void Remove()
    {
        cam.transform.SetParent(null);
    }
    
}
