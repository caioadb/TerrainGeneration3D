using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float sensitivity = 50f;
    public float moveSpeed = 10f;
    Camera cam;
    bool canMove;

    private void Start()
    {
        cam = GetComponent<Camera>();
        canMove = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            CamMovement();
        }
        
        if (Input.GetMouseButton(0))//right click
        {
            canMove = true;
            Cursor.visible = false;
        }
        /*        if (Input.GetMouseButton(1))//right click
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }

                if (Input.GetMouseButtonUp(1) ){
                    Cursor.lockState = CursorLockMode.None;
                }*/

        if (Input.GetButtonDown("Cancel"))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                canMove = true;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                canMove = false;
                Cursor.visible = true;
            }
        }
    }

    void CamMovement()    // allows for camera movement
    {

        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // AD or left right keys move camera to the sides
        float y = Input.GetAxis("Vertical") * moveSpeed  * Time.deltaTime; // WS or up down keys move camera up and down
        transform.Translate(x * Vector3.right, Space.Self);
        transform.Translate(y * Vector3.forward, Space.Self);

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // moves camera forward or backwards
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * sensitivity * 50f * Time.deltaTime, Space.Self);
        }

        //if (Input.GetMouseButton(1)) //right mouse button held down allow camera rotation
        //{
            float pitch = Input.GetAxis("Mouse Y") * -1f * sensitivity * 20 * Time.deltaTime;
            cam.transform.Rotate(pitch * Vector3.right, Space.Self);            

            float yaw = Input.GetAxis("Mouse X") * sensitivity * 20 * Time.deltaTime;
            cam.transform.Rotate(yaw * Vector3.up, Space.World);
        //}

    }
}
