using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject axe;

    public float speed = 10.0f;

    private float bound = -10;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        axe.transform.Rotate(Vector3.right, 720 * Time.deltaTime);
        if(transform.position.z < bound)
        {
            Destroy(gameObject);
        }
    }
}
