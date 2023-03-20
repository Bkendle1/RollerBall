using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterCamera : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private bool useCustomOffset;
    [SerializeField] private float smoothRate = .1f;

    private Vector3 newTarget;
    private Vector3 smoothFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!useCustomOffset)
        {
            offSet = transform.position = playerPos.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        SmoothFollowUpdate();
    }

    private void SmoothFollowUpdate()
    {
        //Calculte new position for camera but have it
        //move there at a certain rate to make it smoother
        newTarget = playerPos.position + offSet;
        smoothFollow = Vector3.Lerp(transform.position, newTarget, smoothRate);

        transform.position = smoothFollow;
        transform.LookAt(playerPos);
    }
}
