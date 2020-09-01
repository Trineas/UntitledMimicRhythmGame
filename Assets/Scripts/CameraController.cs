using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, 0f, 0f) - offset;
    }
}
