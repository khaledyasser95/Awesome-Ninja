using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoyStick : MonoBehaviour {
    private Transform playerTransform;
    private Animator anim;

    private AudioSource audioSource;
    public AudioClip footStep1,footStep2;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerTransform = this.transform;
	}
    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += JoyStickMove;
        EasyJoystick.On_JoystickMoveEnd += JoyStickMoveEnd;

    }
    void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= JoyStickMove;
        EasyJoystick.On_JoystickMoveEnd -= JoyStickMoveEnd;
    }	
	// Update is called once per frame
	void Update () {
		
	}

    void JoyStickMove(MovingJoystick move)
    {
        float angle = move.Axis2Angle(true);
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, angle - 45, 0));
        anim.SetBool(AnimationStates.ANIMATION_RUN, true);
    }
    void JoyStickMoveEnd(MovingJoystick move)
    {
        anim.SetBool(AnimationStates.ANIMATION_RUN, false);
    }

    void FootStepOne(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(footStep1);
        }
    }
    void FootStepTwo(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(footStep2);
        }
    }
}
