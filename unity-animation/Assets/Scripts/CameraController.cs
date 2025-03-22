using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 3, -5);  // Camera offset from player
    public float rotationSpeed = 3f; // Mouse sensitivity
    public bool requireRightClick = true; // If true, camera rotates only when right-click is held
    public bool isInverted = false; // New bool to control Y-axis inversion

    private float yaw = 0f; // Horizontal rotation
    private float pitch = 0f; // Vertical rotation

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Load the stored inversion setting
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;

        transform.position = player.position + offset;
        transform.LookAt(player.position); // Make sure camera starts looking at the player
    }
    
    void LateUpdate() {
        if (player == null) return;

        // Follow the player's position but do not inherit rotation
        transform.position = player.position + offset;

        bool shouldRotate = !requireRightClick || Input.GetMouseButton(1);
        if (shouldRotate) {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;

            float mouseY = Input.GetAxis("Mouse Y");
            pitch += (isInverted ? mouseY : -mouseY) * rotationSpeed; // Apply inversion
            pitch = Mathf.Clamp(pitch, -30f, 60f);

            // Only apply rotation to the camera itself, not the player
            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }

    public void ResetCameraPosition() {
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
