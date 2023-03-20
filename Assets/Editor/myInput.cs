using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class myInput : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 inputAxis = Vector2.zero;
    
    public float speed;
    public InputAction movement;

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputAxis = movement.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(inputAxis.x, 0f,inputAxis.y);
        
        //Apply force to player and give it magnitude from speed
        rb.AddForce(force * speed);
    }
}
