using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 3, -5);  // Camera offset from player
    public float rotationSpeed = 3f; // Mouse sensitivity
    public bool requireRightClick = true; // If true, camera rotates only when right-click is held

	private float yaw = 0f; // Horizontal rotation
	private float pitch = 0f; // Vertical rotation

	// Use this for initialization
	void Start () {
		// Lock and hide the cursor for better control
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		// Apply initial offset
		transform.position = player.position + offset;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (player == null) return;

		// Follow the player
		transform.position = player.position + offset;

		// Handle camera rotation
		bool shouldRotate = !requireRightClick || Input.GetMouseButton(1);
		if (shouldRotate) {
			yaw += Input.GetAxis("Mouse X") * rotationSpeed;
			pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
			pitch = Mathf.Clamp(pitch, -30f, 60f); // Limit vertical rotation

			// Rotate the camera
			transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
		}
	}

	public void ResetCameraPosition()
    {
        transform.position = player.position + offset;
    }
}
