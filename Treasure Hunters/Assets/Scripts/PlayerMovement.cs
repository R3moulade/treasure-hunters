using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxPower = 100f;
    public Transform directionIndicator;

    private Vector3 mouseStartPos;
    private Vector3 mouseEndPos;
    private bool isDragging = false;



    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // When the left mouse button is pressed, record the start position
            mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseStartPos.z = 0; 
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) {
            // When the mouse button is released, calculate the power and apply force
            mouseEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseEndPos.z = 0; 
            ApplyForce();
            isDragging = false;
        }

        if (isDragging) {
            // Optional: Update direction indicator here
            UpdateDirectionIndicator();
        }
    }

    private void ApplyForce() {
        float power = Mathf.Min(maxPower, Vector3.Distance(mouseStartPos, mouseEndPos) * 0.5f); 
        Vector2 forceDirection = (mouseStartPos - mouseEndPos).normalized; 
        rb.AddForce(forceDirection * power, ForceMode2D.Impulse); 
    }

    private void UpdateDirectionIndicator() {
        if (directionIndicator != null) {
            // Calculate the current mouse position in world space
            Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePos.z = 0;

            // Calculate the direction and distance
            Vector3 direction = mouseStartPos - currentMousePos;
            float distance = direction.magnitude;

            // Set the start and end points for the line renderer
            LineRenderer lr = directionIndicator.GetComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.SetPosition(0, transform.position); // Start at the player's position
            lr.SetPosition(1, transform.position + direction.normalized * distance); // End point based on drag distance

            // Optionally, adjust the line width or color based on the distance
            lr.startWidth = 1f;
            lr.endWidth = 1f; // Or make the end width larger to indicate direction
        }
    }

}
