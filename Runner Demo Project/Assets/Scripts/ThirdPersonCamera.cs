using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform paintBrush;
    [SerializeField] private float smoothSpeed = 0.125f;
    public Vector3 offset;
    public GameData data;
    public Vector3 paintOffset;
    void FixedUpdate()
    {
        if (data.paintPhase == false)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            Vector3 desiredPosition = paintBrush.position + paintOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
