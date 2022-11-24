using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRightPlatform : MonoBehaviour
{
    public float speed = 2.5f;

    public float zPosition;
    public float zRange = 5;

    void Start() {
        zPosition = transform.position.z;
    }

    void Update() {
        Move();
        PlatformBounds();
    }

    void Move() {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void PlatformBounds() {
        if(transform.position.z >= zPosition + zRange / 2) {
            transform.Rotate(Vector3.up, 180);
        }
        else if(transform.position.z <= zPosition - zRange / 2) {
            transform.Rotate(Vector3.up, 180);
        }
    }
}
