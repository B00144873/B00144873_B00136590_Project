using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    public float horizontalInput;
    public float verticalInput;
    public float horizontalSpeed = 20;
    public float verticalSpeed = 10;

    public float jumpForce = 25;
    public float jumpGravity = 5;
    public bool grounded = true;

    public float xRange = 5;

    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI winText;
    public Button menuButton;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI bananaText;
    public TextMeshProUGUI satsumaText;

    public float timeLeft;

    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        Physics.gravity *= jumpGravity;
    }

    void Update() {
        Move();
        Jump();
        PlayerBounds();

        timeLeft -= Time.deltaTime;
        timeLeftText.text = "Time Left: " + Mathf.Round(timeLeft) + "s";

        if(timeLeft < 0)
        {
            Lose();
        }
        if(transform.position.y < -10)
        {
            Lose();
        }
    }

    private void Move() {
        // horizontalInput = Input.GetAxis("Horizontal");
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
        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;

            playerAnimator.SetBool("JumpOrFall", true);
        }
    }

    private void PlayerBounds() {
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    public void Win() {
        Destroy(gameObject);

        Physics.gravity /= jumpGravity;

        winText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        timeLeftText.gameObject.SetActive(false);
        bananaText.gameObject.SetActive(false);
        satsumaText.gameObject.SetActive(false);

        winText.text = "Level completed with " + Mathf.Round(timeLeft) + "s to spare!";
    }

    public void Lose()
    {
        Destroy(gameObject);

        Physics.gravity /= jumpGravity;

        loseText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        timeLeftText.gameObject.SetActive(false);
        bananaText.gameObject.SetActive(false);
        satsumaText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) {
        grounded = true;

        playerAnimator.SetBool("JumpOrFall", false);

        if(collision.gameObject.CompareTag("BouncePlatform")) {
            playerRigidbody.AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
            grounded = false;

            playerAnimator.SetBool("JumpOrFall", true);
        }

        if(collision.gameObject.CompareTag("Goal")) {
            timeLeft = timeLeft;
            Win();
        }
        if(collision.gameObject.CompareTag("Enemy")) {
            Lose();
        }

        if(collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananaText.gameObject.SetActive(true);
            timeLeft += 10;
            satsumaText.gameObject.SetActive(false);
        }

        if(collision.gameObject.CompareTag("Satsuma"))
        {
            Destroy(collision.gameObject);
            satsumaText.gameObject.SetActive(true);
            timeLeft += 15;
            bananaText.gameObject.SetActive(false);
        }
    }
}
