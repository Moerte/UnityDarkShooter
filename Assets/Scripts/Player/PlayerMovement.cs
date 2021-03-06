﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Vector3 movement;
    private Animator animator;
    private PlayerShooting playerShooting;

    private Level level;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }
    private void Start()
    {
        level = GameManager.instance.levels[GameManager.instance.level];
        this.speed = (int)level.playerSpeed;
    }
    private void FixedUpdate()
    {
        float h, v;
        if (!Application.isEditor)
        {
            h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        }
        else
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

        }

        float rotH = CrossPlatformInputManager.GetAxisRaw("RotHorizontal");
        float rotV = CrossPlatformInputManager.GetAxisRaw("RotVertical");

        Move(h, v);
        Turning(rotH, rotV);
        Animating(h, v);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turning(float h, float v)
    {
        Vector3 rot = new Vector3(h, 0, v);
        if(rot != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rot);
            playerShooting.Shoot();
        }
    }
    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        animator.SetBool("Walking", walking);

    }
}
