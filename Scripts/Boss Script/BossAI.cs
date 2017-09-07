using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    private Animator anim;
    private Transform playerTransform;
    private PlayerHealth playerhealth;
    private BossHealth bossHealth;

   
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerhealth = playerTransform.gameObject.GetComponent<PlayerHealth>();
        bossHealth = GetComponent<BossHealth>();

	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (bossHealth.realHealth > 0)
        {
            transform.LookAt(playerTransform);

        }
        if (playerhealth.realHealth <= 0)
        {
            anim.SetBool(AnimationStates.ANIMATION_SKILL_1, false);
            anim.SetBool(AnimationStates.ANIMATION_SKILL_2, false);
            anim.SetBool(AnimationStates.ANIMATION_SKILL_3  , false);
            anim.SetBool(AnimationStates.ANIMATION_WALK, false);
        }
        if (playerhealth.realHealth > 0)
        {
            if (distance > 5f)
            {
                anim.SetBool(AnimationStates.ANIMATION_WALK, true);
                anim.SetBool(AnimationStates.ANIMATION_SKILL_1, false);
                anim.SetBool(AnimationStates.ANIMATION_SKILL_2, false);
                anim.SetBool(AnimationStates.ANIMATION_SKILL_3, false);

            }else
            {
                anim.SetBool(AnimationStates.ANIMATION_WALK, false);
                if (distance > 2.5f)
                {
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_1, true);
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_2, false);
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_3, false);
                }
                if (distance <= 2.5f && distance >0.5f)
                {
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_1, false);
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_2, true);
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_3, false);
                }
                if (distance <= 0.5f)
                {
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_1, false);
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_2, false);
                    anim.SetBool(AnimationStates.ANIMATION_SKILL_3, true);
                }
            }
        }
	}
}
