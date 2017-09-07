using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimationEvent : MonoBehaviour {

    public GameObject attackPointOne;
    public GameObject attackPointTwo;
    public GameObject enemyAttackEffect;

    void EnemyAttackOne(bool isAttacking)
    {
        if (isAttacking)
        {
            Instantiate(enemyAttackEffect, attackPointOne.transform.position, attackPointOne.transform.rotation);

        }
    }

    void EnemyAttackTwo(bool isAttacking)
    {
        if (isAttacking)
        {
            Instantiate(enemyAttackEffect, attackPointTwo.transform.position, attackPointTwo.transform.rotation);

        }
    }

    void EnemyAttackOneStart(bool isAttacking)
    {
        if (isAttacking)
        {
            attackPointOne.SetActive(true);

        }
    }

    void EnemyAttackOneEnd(bool isnotAttacking)
    {
        if (isnotAttacking)
        {
            attackPointOne.SetActive(false);

        }
    }


    void EnemyAttackTwoStart(bool isAttacking)
    {
        if (isAttacking)
        {
            attackPointTwo.SetActive(true);

        }
    }

    void EnemyAttackTwoEnd(bool isnotAttacking)
    {
        if (isnotAttacking)
        {
            attackPointTwo.SetActive(false);

        }
    }
}//class
























