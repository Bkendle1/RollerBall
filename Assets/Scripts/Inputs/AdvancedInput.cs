using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdvancedInput : MonoBehaviour
{
    public exampleInput playerInput;
    public float speed = 10f;
    public Vector3 _startTransform;
    private Rigidbody rb;

    private Vector2 input;

    private InputAction movement;
    private InputAction fire;
    
    private void Awake()
    {
        playerInput = new exampleInput();
    }

    private void OnEnable()
    {
        movement = playerInput.Player.Move;
        movement.Enable();

        fire = playerInput.Player.Fire;
        fire.Enable();
        fire.performed += OnFirePressed;
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _startTransform = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        input = movement.ReadValue<Vector2>().normalized;
    }

    public void ResetPlayer()
    {
        rb.isKinematic = true;
        this.transform.position = _startTransform;
        rb.velocity = Vector3.zero;
        rb.rotation = quaternion.identity;
        rb.isKinematic = false;
    }
    
    private void FixedUpdate()
    {
        Vector3 force = new Vector3(input.x, 0f, input.y);
        rb.AddForce(force * speed);
    }

    private void OnFirePressed(InputAction.CallbackContext context)
    {
        Debug.Log("Fired pressed.");
        
    }
}
