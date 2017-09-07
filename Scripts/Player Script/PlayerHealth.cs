using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {
    public float realHealth;
    private bool playerDead;
    private bool playerBeHit;
    private Animator anim;

    private Slider healthSlider;
   private Text healthText;

    private BossHealth bossHealth;
    private Transform bossTransform;
    private bool victory;

    

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        healthSlider = GameObject.Find("Health Foreground").GetComponent<Slider>();
        healthText = GameObject.Find("Health Text").GetComponent<Text>();

        healthText.text = realHealth.ToString();
        healthSlider.value = realHealth;
        bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
        bossHealth = bossTransform.gameObject.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update () {
		if (realHealth <= 0)
        {
            realHealth = 0;
            PlayerDying();
        }
        if (playerDead)
        {
            StopPlayerDeadAnimation();
        }
        if (realHealth > 100)
            realHealth = 100f;

        if (bossHealth.realHealth <= 0)
        {
            Victory();
        }
        if (victory)
        {
            StopVictoryAnimation();
        }
        
	}
    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(AnimationStates.ANIMATION_DEAD, true);
        anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);

    }
    void StopPlayerDeadAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(AnimationStates.BASE_LAYER_DYING))
        {
            anim.SetBool(AnimationStates.ANIMATION_DEAD, false);

        }
    }

    public void TakeDamage(float amount)
    {
        realHealth -= amount;
        if (realHealth <= 0)
        {
            realHealth = 0;
        }
        if (amount > 0)
        {
            healthText.text = realHealth.ToString();
            healthSlider.value = realHealth;
            playerBeHit = true;
        }
    }

    void Victory()
    {
        anim.SetBool(AnimationStates.ANIMATION_VICTORY, true);
        victory = true;
    }
    void StopVictoryAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(AnimationStates.ANIMATION_VICTORY))
        {
            anim.SetBool(AnimationStates.ANIMATION_VICTORY, false);
        }
    }
}
