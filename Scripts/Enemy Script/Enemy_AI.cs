using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_AI : MonoBehaviour {

    private Transform zombieTransform;

    public float chaseSpeed;
    private CapsuleCollider col;
    private Transform player;
    private Animator anim;
    private Enemy_Health enemyHealth;
    private PlayerHealth playerHealth;
    private bool victory;


    private NavMeshAgent navAgent;
    public Transform[] navPoints;
    private int navigationIndex;
	// Use this for initialization
	void Awake () {
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieTransform = this.transform;
        enemyHealth = GetComponent<Enemy_Health>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        navAgent = GetComponent<NavMeshAgent>();
        navigationIndex = Random.Range(0, navPoints.Length);

	}
	
	// Update is called once per frame
	void Update () {
        AttackOrRun();

    }//update

    void AttackOrRun()
    {
        float distance = Vector3.Distance(zombieTransform.position, player.position);
        //if (enemyHealth.realHealth > 0)
        //{
        //    if (distance > 2.5f)
        //    {
        //        Chase();
        //    }else
        //    {
        //        Attack();
        //    }
        //    transform.LookAt(player);
        //}
        if (enemyHealth.realHealth > 0)
        {
            if (distance > 7f)
            {
                Search();
                navAgent.Resume();

            }
            else
            {
                navAgent.Stop();
                if (distance > 2.5f)
                {
                    Chase();
                }
                else
                {
                    Attack();
                }
                transform.LookAt(player);

            }
        }
        if (enemyHealth.realHealth <= 0)
        {
            col.enabled = false;
        }
        if (playerHealth.realHealth <= 0)
        {
            EnemyVictory();
        }
        if (victory)
        {
            EnemyIsVictory();
        }
    }
    void EnemyVictory()
    {
        anim.SetBool(AnimationStates.ANIMATION_VICTORY, true);
        victory = true;
    }
    void EnemyIsVictory()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(AnimationStates.BASE_LAYER_STAND))
        {
            anim.SetBool(AnimationStates.ANIMATION_VICTORY, false);
        }
    }
    void Search()
    {
        if (navAgent.remainingDistance <= 0.5f)
        {
            anim.SetFloat(AnimationStates.ANIMATION_SPEED, 0f);
            anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);
            anim.SetBool(AnimationStates.ANIMATION_RUN, false);
            if (navigationIndex == navPoints.Length - 1)
            {
                navigationIndex = 0;
            }else
            {
                navigationIndex++;
            }
            navAgent.SetDestination(navPoints[navigationIndex].position);
        }else
        {
            anim.SetFloat(AnimationStates.ANIMATION_SPEED, 1f);
            anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);
            anim.SetBool(AnimationStates.ANIMATION_RUN, false);
        }
    }
    void Chase()
    {
        anim.SetBool(AnimationStates.ANIMATION_RUN, true);
        anim.SetFloat(AnimationStates.ANIMATION_SPEED, chaseSpeed);
        anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);
    }
    void Attack()
    {
        anim.SetBool(AnimationStates.ANIMATION_ATTACK, true);
    }
}//class


























