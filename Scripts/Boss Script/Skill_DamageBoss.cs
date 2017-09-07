using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DamageBoss : MonoBehaviour {
    public LayerMask bossLyaer;
    public float radius;
    public float damageCount;
    public GameObject damageEffect;

    private bool collided;
    private BossHealth bossHealth;

	
	
	// Update is called once per frame
	void Update () {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, bossLyaer);
        foreach (Collider c in hits)
        {
            if (c.isTrigger)
                continue;
            collided = true;
            bossHealth = c.gameObject.GetComponent<BossHealth>();
            if (collided)
            {
                Instantiate(damageEffect, transform.position, transform.rotation);
                bossHealth.BossTakeDamage(damageCount);
                Destroy(gameObject);
            }
        }
    }
}
