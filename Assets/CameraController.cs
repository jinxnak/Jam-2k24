using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        cameraMove();
    }

    private void cameraMove ()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position + offset;
            transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
