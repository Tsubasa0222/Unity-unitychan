using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript2 : MonoBehaviour
{
    Rigidbody rb;
    Animator ani;
    public float jumpForce ;
    private bool isgrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
    }
    public void JumpButton()
    {
        if (!isgrounded)
        {
            rb.velocity = Vector3.up * this.jumpForce;
            ani.SetBool("Jump", true);
            isgrounded =true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grand"))
        {
            ani.SetBool("Jump", false);
            isgrounded = false;
        }
    }
}