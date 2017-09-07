    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Move : MonoBehaviour {

    public float speed_X = 0f, speed_Y = 0f, speed_Z = 0f;
    public bool local = false;
    
	// Update is called once per frame
	void Update () {
	if (local)
        {
            transform.Translate(new Vector3(speed_X, speed_Y, speed_Z)*Time.deltaTime);
        }else
        {
            transform.Translate(new Vector3(speed_X, speed_Y, speed_Z) * Time.deltaTime,Space.World);
        }	

	}
}//class


































