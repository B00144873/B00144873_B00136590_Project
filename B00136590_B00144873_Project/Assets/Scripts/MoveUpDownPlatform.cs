using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownPlatform : MonoBehaviour
{
    public float speed = 2.5f;

    public float yPosition;
    public float yRange = 5;

    void Start() {
        yPosition = transform.position.y;
    }

    void Update() {
        Move();
        PlatformBounds();
    }

    void Move() {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void PlatformBounds() {
        if(transform.position.y >= yPosition + yRange / 2) {
            transform.Rotate(Vector3.left, 180);
        }
        else if(transform.position.y <= yPosition - yRange / 2) {
            transform.Rotate(Vector3.left, 180);
        }
    }
}
