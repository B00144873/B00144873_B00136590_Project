using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    public float horizontalInput;
    public float verticalInput;
    public float horizontalSpeed = 20;
    public float verticalSpeed = 10;

    public float jumpForce = 10;
    public float jumpGravity = 2;
    public bool grounded = true;

    private Animator playerAnimator;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        Physics.gravity *= jumpGravity;
    }

    void Update() {
        Move();
        Jump();
    }

    private void Move() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalSpeed * verticalInput);

        if(verticalInput > 0) playerAnimator.SetBool("MoveForwards", true);
        else if(verticalInput < 0) playerAnimator.SetBool("MoveBackwards", true);
        else {
            playerAnimator.SetBool("MoveForwards", false);
            playerAnimator.SetBool("MoveBackwards", false);
        }

        if(horizontalInput > 0) playerAnimator.SetBool("MoveRight", true);
        else if(horizontalInput < 0) playerAnimator.SetBool("MoveLeft", true);
        else {
            playerAnimator.SetBool("MoveRight", false);
            playerAnimator.SetBool("MoveLeft", false);
        }
    }

    private void Jump() {
        if(Input.GetKeyDown(KeyCode.Space) && grounded) playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            grounded = true;

            playerAnimator.SetBool("JumpOrFall", false);
        }
    }
    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            grounded = false;

            playerAnimator.SetBool("JumpOrFall", true);
        }
    }
}
