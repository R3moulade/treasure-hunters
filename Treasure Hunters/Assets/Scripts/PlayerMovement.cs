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

    void Start() {
        LineRenderer lr = directionIndicator.GetComponent<LineRenderer>();
        if (lr != null) {
            lr.startWidth = 0.1f;  // Constant width at the start of the line
            lr.endWidth = 0.1f;    // Constant width at the end of the line
        }
    }

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

        // Make the direction line disappear
        LineRenderer lr = directionIndicator.GetComponent<LineRenderer>();
        if (lr != null) {
            lr.positionCount = 0;
        }
    }

    private void UpdateDirectionIndicator() {
        if (directionIndicator != null) {
            directionIndicator.position = transform.position; // Keep the indicator at the player's position

            Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePos.z = 0;

            // This represents the direction from the drag start to the current mouse position
            Vector3 dragDirection = mouseStartPos - currentMousePos;

            // This will be the direction the ball actually moves, which is the reverse of the drag
            Vector3 forceDirection = -dragDirection.normalized;
            float distance = dragDirection.magnitude;

            LineRenderer lr = directionIndicator.GetComponent<LineRenderer>();
            if (lr != null) {
                lr.positionCount = 2;
                // Here we reverse the direction to indicate the actual force direction
                lr.SetPosition(0, Vector3.zero); // Start at the GameObject's local position, which is now the player's position
                lr.SetPosition(1, forceDirection * distance); // Set the line in the opposite direction of the drag
            }
        }
    }



}
