using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{
   public float mouseXSensitivity;
   public float mouseYSensitivity;
   private float mouseXMovement;
   private float mouseYMovement;
    public bool invertY;
    private float invert;
    private Vector2 reset = new Vector2(0, 0);
    public Texture2D cursorTexture;
    private float xPosition;
    private float yPosition;
    public GameObject flight;
    public bool toggle;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, reset, CursorMode.Auto);
        
    }
    private void Update()
    {
        

       mouseXMovement = Input.GetAxis("Mouse X");
        mouseYMovement = Input.GetAxis("Mouse Y");

        if(invertY == true)
        {
            invert = -1;
        }
        else
        {
            invert = 1f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(toggle == true)
            {
                toggle = false;
                flight.SetActive(true);
            }
            else
            {
                flight.SetActive(false);
                toggle = true;
            }
        }
        if(Input.GetButton("Fire2"))
        {
            xPosition = xPosition + mouseXMovement * mouseXSensitivity;
            yPosition = yPosition + invert * mouseYMovement * mouseYSensitivity;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("Click");
            transform.rotation = Quaternion.Euler(yPosition, xPosition, 0);
        }
        if(Input.GetButtonUp("Fire2"))
        {
            
            Cursor.SetCursor(cursorTexture, reset, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
