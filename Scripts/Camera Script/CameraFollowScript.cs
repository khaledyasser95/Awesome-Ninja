using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    private Transform myTransform;
    private Transform target;
    public Vector3 offset = new Vector3(3f, 7.5f, -3f);

    // Use this for initialization
    void Awake()
    {
        target = GameObject.Find("Ninja").transform;
    }
    void Start () {
        myTransform = this.transform;	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
        {
            myTransform.position = target.position + offset;
            myTransform.LookAt(transform.position, Vector3.up);
        }
	}
}//class




































