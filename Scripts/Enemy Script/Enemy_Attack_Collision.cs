using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_Collision : MonoBehaviour {
    public LayerMask playerLayer;
    public float radius;
    private bool collided;

    public Transform hitPoint;
    public float damageCount;

    private Transform player;
    private PlayerHealth playerHealth;
	// Use this for initialization
	void Awake () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        Collider[] hits = Physics.OverlapSphere(hitPoint.position,radius,playerLayer);
        foreach(Collider c in hits)
        {
            if (c.isTrigger)
                continue;
            collided = true;
        if (collided)
        {
            playerHealth.TakeDamage(damageCount);
        }
        }
       
	}
}
