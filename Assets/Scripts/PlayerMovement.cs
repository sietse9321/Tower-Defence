using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    //floats
    public float moveSpeed = 10f;
    public float rotationSpeed = 200f;
    public float moveHorizontal;
    public float moveVertical;
    public float moveUp, moveDown;
    public float yaw, pitch;
    private bool isSelecting = false;

    void Update()
    {
        //if key pressed down do code
        if (Input.GetKeyDown(KeyCode.E))
        {
            //if bool is equal to false do code
            if (isSelecting == false)
            {
                //set bool true
                isSelecting = true;
                //set cursorlockstate to none
                Cursor.lockState = CursorLockMode.None;
            }
            //else if bool is equal to true do code
            else if (isSelecting == true)
            {
                isSelecting = false;
                //locks and hides the cursor
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        //if bool is equal to false do code
        if (isSelecting == false)
        {
            //calls method
            Movement();
        }
    }

    void Movement()
    {
        // Movement controls
        //input control for horizontal and vertical can only be 0 or 1
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        //sets moveUp based on if the space is press if so makes it 1 else 0
        moveUp = Input.GetKey(KeyCode.Space) ? 1f : 0f;
        moveDown = Input.GetKey(KeyCode.LeftShift) ? -1f : 0f;

        //sets the direction uses                (x)              (y)              (z)
        Vector3 moveDirection = new Vector3(moveHorizontal, moveUp + moveDown, moveVertical);
        //sets the movedirection based on tranform direction using moveDirection
        moveDirection = transform.TransformDirection(moveDirection);
        //sets this gameobject transform.position plus movespeed * time * direction
        transform.position += moveSpeed * Time.deltaTime * moveDirection;

        // Rotation controls
        //yam plus rotationspeed * mouse x/y * time
        yaw += rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
