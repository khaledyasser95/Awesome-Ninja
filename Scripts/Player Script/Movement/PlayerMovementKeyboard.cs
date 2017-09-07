using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeyboard : MonoBehaviour {
    private Animator anim;
    public FreeMovementMotor motor;
    public Transform playerTransform;
    private Rigidbody mybody;
    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementright;

    private string Axis_Y = "Vertical";
    private string Axis_X = "Horizontal";
    // Use this for initialization
    void Awake () {
        anim=GetComponent<Animator>();
        motor.movementDirection = Vector2.zero;
        mybody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementright = screenMovementSpace * Vector3.right;
    }
	
	// Update is called once per frame
	void Update () {
        motor.movementDirection = Input.GetAxis(Axis_X) * screenMovementright + Input.GetAxis(Axis_Y) * screenMovementForward;
		if (Input.GetAxis(Axis_X)!=0 || Input.GetAxis(Axis_Y) != 0)
        {
           
            anim.SetBool(AnimationStates.ANIMATION_RUN, true);
        }else
        {
            anim.SetBool(AnimationStates.ANIMATION_RUN, false);
        }
        if (motor.movementDirection.sqrMagnitude > 1)
            motor.movementDirection.Normalize();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mybody.AddForce(new Vector3(0, 500, 0));
        }

    }
}
