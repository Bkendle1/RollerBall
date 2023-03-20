using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public float speed = 0f;

    private Rigidbody rb; 
    private float movementX = 0f;
    private float movementY = 0f;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(movementX, 0f, movementY);
        
        //Apply force to player and give it magnitude from speed
        rb.AddForce(force * speed);
    }
    
    private void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();
        movementX = movement.x;
        movementY = movement.y;
    }
    
}
