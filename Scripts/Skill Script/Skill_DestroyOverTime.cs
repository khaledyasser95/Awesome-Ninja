using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DestroyOverTime : MonoBehaviour {
    public float Timer = 3f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject,Timer);
	}
	
	
}
