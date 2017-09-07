using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour {

    public LayerMask enemyLayer;
    public float radius;
    public GameObject attackEffect;
    private bool collided;
    public Transform hitPoint;
    public float damageCount;
    private Enemy_Health enemyHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Collider[] hits = Physics.OverlapSphere(hitPoint.position,radius,enemyLayer);
        foreach (Collider c in hits)
        {
            if (c.isTrigger)
                continue;
            enemyHealth = c.gameObject.GetComponent<Enemy_Health>();
            collided = true;
            if (collided)
            {
                Instantiate(attackEffect, hitPoint.position, hitPoint.rotation);
                enemyHealth.EnemyTakeDamage(damageCount);
            }
        }
       
	}
}
