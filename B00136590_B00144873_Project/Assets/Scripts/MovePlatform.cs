using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {
    public float speed = 5;

    void Start() {
    }

    void Update() {
        Move();
    }

    private void Move() {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
