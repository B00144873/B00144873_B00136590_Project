using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour {
    private Rigidbody enemyRigidbody;

    public float speed = 2.5f;

    public float zPosition;
    public float zRange = 5;

    private Animator enemyAnimator;

    void Start() {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyAnimator = GetComponent<Animator>();

        zPosition = transform.position.z;
    }

    void Update() {
        Move();
        EnemyBounds();
    }

    void Move() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void EnemyBounds() {
        if(transform.position.z >= zPosition + zRange / 2) {
            transform.Rotate(Vector3.up, 180);
        }
        else if(transform.position.z <= zPosition - zRange / 2) {
            transform.Rotate(Vector3.up, 180);
        }
    }
}
