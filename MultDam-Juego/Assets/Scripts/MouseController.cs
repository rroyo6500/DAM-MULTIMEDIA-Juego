using System;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    public float sensitivity = 15f;
    public GameObject player;
    
    public Vector2 VirtualMousePos { get; private set; }
    
    public Vector2 WorldMousePos { get; private set; }
    
    private Rigidbody2D mouseVisualSprite;
    private Camera playerCam;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mouseVisualSprite = GetComponentInChildren<Rigidbody2D>();
        playerCam = player.GetComponentInChildren<Camera>();
        
        VirtualMousePos = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }

    private void Update()
    {
        float movX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float movY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        if (movX != 0f || movY != 0f)
        {
            VirtualMousePos += new Vector2(movX, movY);

            VirtualMousePos = new Vector2(
                Mathf.Clamp(VirtualMousePos.x, 0f, Screen.width),
                Mathf.Clamp(VirtualMousePos.y, 0f, Screen.height)
            );
        }
    }

    private void FixedUpdate()
    {
        if (playerCam == null) return;

        float zDistance = Mathf.Abs(playerCam.transform.position.z);
        Vector3 screenPoint = new Vector3(VirtualMousePos.x, VirtualMousePos.y, zDistance);

        WorldMousePos = playerCam.ScreenToWorldPoint(screenPoint);
        
        mouseVisualSprite.MovePosition(WorldMousePos);
    }
}