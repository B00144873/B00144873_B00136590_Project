using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;

    void Start() {
    }

    void LateUpdate() {
        transform.position = player.transform.position + new Vector3(7, 4, -4);
    }
}
