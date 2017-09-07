using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartMove : MonoBehaviour {
    private SphereCollider col;
    private BossAI bossAi;

	// Use this for initialization
	void Awake () {
        col = GetComponent<SphereCollider>();
        bossAi = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>();

	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider target) {
		if (target.tag == "Player")
        {
            bossAi.enabled = true;
            col.enabled = false;
        }
	}
}
