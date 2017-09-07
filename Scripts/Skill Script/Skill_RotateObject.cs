using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_RotateObject : MonoBehaviour {

    public float rotationSpeed_X = 0f;
    public float rotationSpeed_Y = 0f;
    public float rotationSpeed_Z = 0f;
    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(rotationSpeed_X, rotationSpeed_Y, rotationSpeed_Z)*Time.deltaTime);
	}

}//class
