using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementMotor : MonoBehaviour {

    [HideInInspector]
    public Vector3 movementDirection;

    private Rigidbody mybody;

    public float walkingSpeed = 5f;
    public float walkingSnappyness = 15f;
    public float turningSmoothing = 0.3f;
	// Use this for initialization
	void Awake () {
        mybody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetVelocity = movementDirection * walkingSpeed;
        Vector3 deltaVelocity = targetVelocity - mybody.velocity;
        if (mybody.useGravity)
            deltaVelocity.y = 0f;
        mybody.AddForce(deltaVelocity * walkingSnappyness, ForceMode.Acceleration);
        Vector3 faceDir = movementDirection;
        if (faceDir == Vector3.zero)
        {
            mybody.angularVelocity = Vector3.zero;
        }else
        {
            float rotaionangle = AngleAroundAxis(transform.forward,faceDir,Vector3.up);
            mybody.angularVelocity = (Vector3.up * rotaionangle * turningSmoothing);
        }
	}

    float AngleAroundAxis(Vector3 dirA,Vector3 dirB, Vector3 axis)
    {
        dirA = dirA - Vector3.Project(dirA,axis);
        dirB = dirB - Vector3.Project(dirB, axis);
        float angle = Vector3.Angle(dirA, dirB);

        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
    }
}
