using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    private Vector3 currentRefVelocity;

    private void Start()
    {
        currentRefVelocity = Vector3.zero;
    }

    private void Update()
    {
        Vector3 followTarget = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, followTarget, ref currentRefVelocity, smoothness);
    }
}
