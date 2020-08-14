using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireRate, fireRate);
    }

    void Fire()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}
