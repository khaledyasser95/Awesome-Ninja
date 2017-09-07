using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour {

    public GameObject skill3;
    public GameObject skill3point;

    public AudioClip earthHit;
    private AudioSource audioSource;

    public GameObject skill1;
    public GameObject []Skill1_Point_Array;
   

    public GameObject sword;
    public GameObject hitPoint;
    private MeleeWeaponTrail swordTrail;
    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        swordTrail = sword.GetComponent<MeleeWeaponTrail>();

	}
	void Skill1(bool execute)
    {
        if (execute)
        {
            for (int i=0;i<10;i++)
            Instantiate(skill1, Skill1_Point_Array[i].transform.position, Skill1_Point_Array[i].transform.rotation);
            StartCoroutine(Skill1Afterwait());
        }
    }
    void Skill3(bool execute)
    {
        if (execute)
        {
            Instantiate(skill3, skill3point.transform.position, skill3point.transform.rotation);
            audioSource.PlayOneShot(earthHit);
        }
    }

    void SwordSlashAttack(bool isAttacking )
    {
        if (isAttacking)
        {
            swordTrail.Emit = true;
            hitPoint.SetActive(true);
        }

    }

    void SwordSlashAttackEnd(bool attackEnd)
    {
        if (attackEnd)
        {
            swordTrail.Emit = false;
            hitPoint.SetActive(false);
        }
    }
    IEnumerator Skill1Afterwait()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 10; i++)
            Instantiate(skill1, Skill1_Point_Array[i].transform.position, Skill1_Point_Array[i].transform.rotation);
    }
}
