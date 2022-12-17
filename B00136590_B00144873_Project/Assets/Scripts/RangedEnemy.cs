using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectile;

    public float delay = 2;
    public float interval = 1.5f;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", delay, interval);
    }

    void Update()
    {
    }

    void LaunchProjectile()
    {
        Instantiate(projectile, transform.position, projectile.transform.rotation);
    }
}
