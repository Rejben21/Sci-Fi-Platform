using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget, player, scope;
    private new Transform transform;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private bool isSmoothCamera, isStillCamera, isLeaningCamera;

    public enum CameraType
    {
        SmoothCamera,
        StillCamera,
        LeaningCamera,
    }

    public CameraType cameraType;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        switch(cameraType)
        {
            case CameraType.SmoothCamera:
                isStillCamera = false;
                isLeaningCamera = false;
                isSmoothCamera = true;
                break;

            case CameraType.StillCamera:
                isSmoothCamera = false;
                isLeaningCamera = false;
                isStillCamera = true;
                break;

            case CameraType.LeaningCamera:
                isSmoothCamera = false;
                isStillCamera = false;
                isLeaningCamera = true;
                break;
        }

        if(isStillCamera)
        {
            transform.position = player.position + offset;
        }
        else if(isSmoothCamera)
        {
            SmoothCamera();
        }
        else if(isLeaningCamera)
        {
            LeaningCamera();
        }
    }

    private void SmoothCamera()
    {
        Vector3 desiredPosition = cameraTarget.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void LeaningCamera()
    {
        Vector3 firstPosition = (player.position + scope.position) / 2;
        Vector3 secondPosition = (player.position + firstPosition) / 2;
        Vector3 desiredPosition = ((player.position + secondPosition) / 2) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
