using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 7f; //Movement speed
	public float jumpForce = 5f; // Jump force
	private Rigidbody rb;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();	
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
