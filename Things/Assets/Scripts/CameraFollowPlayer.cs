using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform followPlayer;
    private Transform cameraTransform;
    public Vector3 playerOffset;
    private float speed = 20.0f;
    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = transform;
    }

    public void SetTarget(Transform newTransformTarget)
    {
        followPlayer = newTransformTarget;
    }
//Update is called once per frame
    private void LateUpdate()
    {
        if (followPlayer != null)
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, followPlayer.position + playerOffset, speed * Time.deltaTime);
    }
}
