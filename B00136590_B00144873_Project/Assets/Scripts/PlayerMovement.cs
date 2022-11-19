using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody playerRigidbody;

    public float horizontalInput;
    public float verticalInput;
    public float horizontalSpeed = 10;
    public float verticalSpeed = 10;

    public float jumpForce = 25;
    public float jumpGravity = 5;
    public bool grounded = true;

    public float xRange = 5;

    private Animator playerAnimator;

    public GameObject movePlatform;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        Physics.gravity *= jumpGravity;
    }

    void Update() {
        Move();
        Jump();
        playerBounds();
    }

    private void Move() {
        horizontalInput = Input.GetAxis("Vertical");
        verticalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * horizontalInput);
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
        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;

            playerAnimator.SetBool("JumpOrFall", true);
        }
    }

    private void playerBounds() {
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        grounded = true;

        playerAnimator.SetBool("JumpOrFall", false);

        if(collision.gameObject.CompareTag("BouncePlatform")) {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;

            playerAnimator.SetBool("JumpOrFall", true);
        }
    }
}
