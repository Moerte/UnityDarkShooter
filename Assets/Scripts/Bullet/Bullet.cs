using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
