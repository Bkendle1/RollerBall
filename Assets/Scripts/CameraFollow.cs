using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    private Vector3 offSet = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - playerPos.position;
    }

    private void LateUpdate()
    {
        transform.position = playerPos.position + offSet;
    }
}
