using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 12f; // Movement speed
    public float jumpForce = 10f; // Jump force
    public Transform startPosition;
    public float fallThreshold = -10f; // The height at which the player respawns

    private Rigidbody rb;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;
    private Animator animator;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

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

        if (moveDirection.magnitude >= 0.1f)
        {
            // Rotate the player to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            // Move the player using Rigidbody for better physics interaction
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

            // Play Running animation if grounded
            if (isGrounded)
            {
                animator.SetBool("isRunning", true);
                animator.Play("Running");
            }
        }
        else if (isGrounded)
        {
            // Play Idle animation
            animator.SetBool("isRunning", false);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true;
            isFalling = false;
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isFalling", false);
        }

        // Detect if player is falling (when not grounded and moving downward)
        if (!isGrounded && !isFalling && rb.velocity.y < -7f) {
            isFalling = true;
            isJumping = false;
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
            Debug.Log("Player is falling");

        }

        // Check if player fell off
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn() {
        // Reset player position
        transform.position = startPosition.position + new Vector3(0, 10, 0); // Respawn above starting position
        rb.velocity = Vector3.zero; // Reset movement velocity
    }

    // Detect when player lands
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isFalling)
            {
                // Trigger Falling Flat Impact animation
                animator.SetBool("isFalling", false);
                animator.Play("Falling Flat Impact");
                Debug.Log("impact");

                // Trigger Getting Up animation after Falling Flat Impact
                StartCoroutine(TriggerGettingUp());
            }

            isGrounded = true;
            isJumping = false;
            isFalling = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);

            // Determine if we return to Running or Idle
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    // Trigger Getting Up animation after Falling Flat Impact
    private IEnumerator TriggerGettingUp()
    {
        yield return new WaitForSeconds(1.0f); // Adjust this delay to match the length of the Falling Flat Impact animation
        animator.SetBool("isGettingUp", true);

        // Wait for the Getting Up animation to finish
        yield return new WaitForSeconds(1.0f); // Adjust this delay to match the length of the Getting Up animation
        animator.SetBool("isGettingUp", false);
    }
}