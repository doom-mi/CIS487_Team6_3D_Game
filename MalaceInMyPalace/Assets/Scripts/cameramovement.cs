using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float movementSpeed = 5.0f; // Adjust this to set the regular movement speed of the camera
    public float zoomSpeed = 5.0f; // Adjust this to set the zoom speed of the camera
    public float rightClickMovementSpeed = 10.0f; // Adjust this to set the movement speed while holding right click
    public float minY = 2.0f; // Minimum Y-axis position for zoom
    public float maxY = 10.0f; // Maximum Y-axis position for zoom
    public float minX = -10.0f; // Minimum X-axis position
    public float maxX = 10.0f; // Maximum X-axis position
    public float minZ = -10.0f; // Minimum Z-axis position
    public float maxZ = 10.0f; // Maximum Z-axis position
    private bool isMovingWithRightClick = false;

    void Update()
    {
        // Perform movement and zooming
        PerformMovement();
        ZoomCamera();
    }

    void PerformMovement()
    {
        // Calculate movement direction based on WASD keys or right mouse button drag
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // If the right mouse button (RMB) is held down, move the camera along X and Y axes
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 move = new Vector3(mouseX, mouseY, 0.0f) * rightClickMovementSpeed * Time.deltaTime;
            transform.Translate(move, Space.Self);
            isMovingWithRightClick = true;
        }
        else
        {
            isMovingWithRightClick = false;

            // Use WASD keys for movement along the Y-axis
            float yMovement = Input.GetAxis("Vertical");
            Vector3 moveDirection = transform.up * yMovement;

            // Move the camera along the Y-axis based on the direction and speed
            transform.Translate(moveDirection.normalized * movementSpeed * Time.deltaTime, Space.World);
        }

        // Use A and D keys for movement along the X-axis
        float xMovement = Input.GetAxis("Horizontal");
        Vector3 xMoveDirection = transform.right * xMovement;

        // Move the camera along the X-axis based on the direction and speed
        transform.Translate(xMoveDirection.normalized * movementSpeed * Time.deltaTime, Space.World);

        // Constrain X-axis position within the specified range
        float newX = Mathf.Clamp(transform.position.x, minX, maxX);

        // Update the position only if it's within the allowed range
        if (newX != transform.position.x)
        {
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

        // Constrain Z-axis position within the specified range
        float newZ = Mathf.Clamp(transform.position.z, minZ, maxZ);

        // Update the position only if it's within the allowed range
        if (newZ != transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        }
    }

    void ZoomCamera()
    {
        // Zoom in/out with scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 newPosition = transform.position + transform.forward * scrollInput * zoomSpeed;
        // Limit the Y-axis position within the specified range
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * zoomSpeed);
    }
}
