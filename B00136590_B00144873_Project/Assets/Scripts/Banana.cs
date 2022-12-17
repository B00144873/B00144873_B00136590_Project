using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, 180 * Time.deltaTime);
    }
}
