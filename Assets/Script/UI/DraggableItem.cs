using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialMousePosition;
    private Vector3 initialObjectPosition;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isDragging)
        {
            // Calculate the position difference
            Vector3 currentMousePosition = GetMouseWorldPosition();
            Vector3 positionOffset = currentMousePosition - initialMousePosition;

            // Restrict movement to X and Y axes
            positionOffset.z = 0f;

            // Move the object
            transform.position = initialObjectPosition + positionOffset;
        }
        else
        {
            // Check for input to start dragging
            if (Input.GetMouseButtonDown(0))
            {
                StartDragging();
            }
        }

        // Check for input to stop dragging
        if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }
    private void StartDragging()
    {
        isDragging = true;
        initialMousePosition = GetMouseWorldPosition();
        initialObjectPosition = transform.position;
    }

    private void StopDragging()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = transform.position.z - mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
