using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField] private Vector3 _rotation = Vector3.forward;
    [SerializeField] private float _rotationSpeed = 5;

    private void Update()
    {
        transform.Rotate(Time.deltaTime * _rotationSpeed * _rotation);
    }
}
