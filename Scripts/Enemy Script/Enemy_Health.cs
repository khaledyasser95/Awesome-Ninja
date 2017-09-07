using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

    public float realHealth;

    private AudioSource audioSource;
    public AudioClip enemyDeadSound;

    private bool enemyDead,enemyIsHit;
    private Animator anim;


    public GameObject deadEffect;
    public Transform deadEffectPoint;

    public GameObject attackPointOne;
    public GameObject attackPointTwo;

    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyDead)
        {
            EnemyDead();
        }
        if (enemyIsHit)
        {
            EnemyAttacked();
        }
        if (!enemyIsHit)
        {
            EnemyHit();
        }
	}
    void EnemyDying()
    {
        anim.SetBool(AnimationStates.ANIMATION_DEAD, true);
        anim.SetBool(AnimationStates.ANIMATION_BE_ATTACKED, false);
        enemyDead = true;
        //Start Coo
        StartCoroutine(DeadEffect());
        attackPointOne.SetActive(false);
        attackPointTwo.SetActive(false);
        audioSource.PlayOneShot(enemyDeadSound);

    }
    void EnemyDead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(AnimationStates.BASE_LAYER_DYING))
        {
            anim.SetBool(AnimationStates.ANIMATION_DEAD, false); 
        }
    }
    public void EnemyTakeDamage(float amount)
    {
        Debug.Log("The Current Health is" + realHealth);
        realHealth -= amount;
        if (realHealth <= 0)
        {
            realHealth = 0;
            EnemyDying();
        }
        if (amount > 0)
        {
            enemyIsHit = true;
        }
    }
    void EnemyAttacked()
    {
        enemyIsHit = false;
        anim.SetBool(AnimationStates.ANIMATION_BE_ATTACKED, true);
        anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);
        transform.Translate(Vector3.back*0.5f);

    }

    void EnemyHit()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(AnimationStates.BASE_LAYER_HIT))
        {
            anim.SetBool(AnimationStates.ANIMATION_BE_ATTACKED, false);
        }
    }

    IEnumerator DeadEffect()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(deadEffect, deadEffectPoint.position, deadEffectPoint.rotation);
        Destroy(gameObject);
    }
}
