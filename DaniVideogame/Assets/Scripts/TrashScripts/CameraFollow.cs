using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - cameraTarget.transform.position;
    }

    void Update()
    {
        Vector3 newPos = cameraTarget.transform.position + _offset;
        transform.position = newPos;
    }
}