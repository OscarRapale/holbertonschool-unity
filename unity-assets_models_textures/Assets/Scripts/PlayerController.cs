using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 5f; //Movement speed
	public float jumpForce = 5f; // Jump force
	public Transform startPosition;
	public float fallThreshold = -10f; // The height at which the player respawns
	private Rigidbody rb;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		if (startPosition == null)
		{
			startPosition = new GameObject("StartPosition").transform;
			startPosition.position = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Player input
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		// Move player
		Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
		transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

		// Jump
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}

		// Check if player fell off
		if (transform.position.y < fallThreshold)
		{
			Respawn();
		}
	}

	void Respawn() {
		// Reset player position
		transform.position = startPosition.position + new Vector3(0, 10, 0); // Respwan above starting position
		rb.velocity = Vector3.zero; // Reset movement velocity
	}

	// Detect when player lands
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}
}
