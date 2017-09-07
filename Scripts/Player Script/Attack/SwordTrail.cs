using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail : MonoBehaviour {
    private MeleeWeaponTrail weaponeTrail;
    private Transform sword;
    public GameObject HitPoint;
    public GameObject slashThreeEffectPrefab;
    public Transform slashThreePoint;

    private AudioSource audioSOurce;
    public AudioClip swordHit1;
    public AudioClip swordHit2;
    public AudioClip earthHitMusic;
    public AudioClip jilaoHnashango;

    
    // Use this for initialization
    void Awake () {
        sword = GameObject.Find("Sword").transform;
        weaponeTrail = sword.gameObject.GetComponent<MeleeWeaponTrail>();
        audioSOurce = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SlashOnWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponeTrail.Emit = true;
            HitPoint.SetActive(true);
            audioSOurce.PlayOneShot(swordHit1);
        }
    }
    void SlashOnWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponeTrail.Emit = false;
            HitPoint.SetActive(false);
        }
    }
    void SlashTwoWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponeTrail.Emit = true;
            HitPoint.SetActive(true);
            audioSOurce.PlayOneShot(swordHit2);
        }
    }
    void SlashTwoWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponeTrail.Emit = false;
            HitPoint.SetActive(false);
        }
    }
    void SlashThreeWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponeTrail.Emit = true;
            HitPoint.SetActive(true);
            audioSOurce.PlayOneShot(jilaoHnashango);
        }
    }
    void SlashThreeWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponeTrail.Emit = false;
            HitPoint.SetActive(false);
        }
    }

    void SlashThreeEffect(bool show)
    {
        if (show)
        {
            Instantiate(slashThreeEffectPrefab, slashThreePoint.position,slashThreePoint.rotation);
            audioSOurce.PlayOneShot(earthHitMusic);
        }
    }

}
