using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeed : MonoBehaviour
{
    public float maxSpeed = 10;
    private Rigidbody localRb;
    // Start is called before the first frame update
    void Start()
    {
        localRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (localRb.velocity.magnitude > maxSpeed)
        {
            localRb.velocity = Vector3.ClampMagnitude(localRb.velocity, maxSpeed);
        }
    }
}
