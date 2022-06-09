using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTransForm;

    [SerializeField]
    private float cameraOffsetZ;
    [SerializeField]
    private float cameraOffsetY;
    public float cameraOffsetX { get; set; } = 0;

    void Update()
    {
        Vector3 camPosition = targetTransForm.position;
        camPosition.z = targetTransForm.position.z + cameraOffsetZ;
        camPosition.y = cameraOffsetY;
        camPosition.x = cameraOffsetX;
        transform.position = camPosition;
    }
}
