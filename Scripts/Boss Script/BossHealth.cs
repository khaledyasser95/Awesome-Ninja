using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public float realHealth;
    public AudioClip deadSOund;
    private AudioSource audioSource;

    private Animator anim;
    private bool isDead;
    private CapsuleCollider col;


    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<CapsuleCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
        {
            StopDeadAnimation();

        }
	}
    void BossDying()
    {
        anim.SetBool(AnimationStates.ANIMATION_DEAD, true);
        isDead = true;
        col.enabled = false;
        audioSource.PlayOneShot(deadSOund);
    }
    public void BossTakeDamage(float amount)
    {
        realHealth -= amount;
        if (realHealth <= 0)
        {
            realHealth = 0;
            BossDying();
        }
    }
    void StopDeadAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(AnimationStates.BASE_LAYER_DEAD))
        {
            anim.SetBool(AnimationStates.ANIMATION_DEAD, false);
        }
    }
}
