using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateWithMouse : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;
    public LayerMask groundLayer; 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveForward();
        }
        RotateWithMouse();
    }

    void MoveForward()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 1.0f, groundLayer))
        {
            Vector3 horizontalMove = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
            transform.Translate(horizontalMove.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        transform.Rotate(Vector3.left, mouseY * rotationSpeed);
    }
}
