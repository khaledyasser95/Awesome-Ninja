using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayersAttack : MonoBehaviour {
    private Animator anim;
    private AudioSource audioSource;
    public GameObject skillOne_EffectPrefab;
    public GameObject skillOne_DamagePrefab;

    public Transform skillOne_Point;
    public Transform skillOne_Point_1;
    public Transform skillOne_Point_2;
    public Transform skillOne_Point_3;
    public Transform skillOne_Point_4;
    public Transform skillOne_Point_5;
    public Transform skillOne_Point_6;
    public Transform skillOne_Point_7;
    public Transform skillOne_Point_8;


    public GameObject skillTwo_EffectPrefab;
    public GameObject skillTwo_DamagePrefab;

    public Transform skillTwo_Point;
    public Transform skillTwo_Point_1;
    public Transform skillTwo_Point_2;
    public Transform skillTwo_Point_3;
    public Transform skillTwo_Point_4;
    public Transform skillTwo_Point_5;
    public Transform skillTwo_Point_6;
   
    public GameObject skillThree_EffectPrefab;
   
    public Transform skillThree_Point_1;
    public Transform skillThree_Point_2;
    public Transform skillThree_Point_3;
    public Transform skillThree_Point_4;
    public Transform skillThree_Point_5;

    public AudioClip skillOneMusic1;
    public AudioClip skillOneMusic2;
    public AudioClip playerSkillOneSound;
    public AudioClip skillTwoMusic;
    public AudioClip skillThreeMusic;

    private Button SkillOne_Btn, SkillTwo_Btn, SkillThree_Btn;

    private bool s1_NotUsed, s2_NotUsed, s3_NotUsed;
    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        SkillOne_Btn = GameObject.Find("Skill 1").GetComponent<Button>();
        SkillTwo_Btn = GameObject.Find("Skill 2").GetComponent<Button>();
        SkillThree_Btn = GameObject.Find("Skill 3").GetComponent<Button>();

        SkillOne_Btn.onClick.AddListener(() => SkillOneButtonPressed());
        SkillTwo_Btn.onClick.AddListener(() => SkillTwoButtonPressed());
        SkillThree_Btn.onClick.AddListener(() => SkillTHreeButtonPressed());
        s1_NotUsed = true;
        s2_NotUsed = true;
        s3_NotUsed = true;
    }
	
	// Update is called once per frame
	void Update () {
        HandleButtonPresses();

    }
    public void SkillOneButtonPressed()
    {
        anim.SetBool(AnimationStates.ANIMATION_SKILL_1, true);
    }
    public void SkillTwoButtonPressed()
    {
        anim.SetBool(AnimationStates.ANIMATION_SKILL_2, true);
    }
    public void SkillTHreeButtonPressed()
    {
        anim.SetBool(AnimationStates.ANIMATION_SKILL_3, true);
    }

    void HandleButtonPresses()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetBool(AnimationStates.ANIMATION_ATTACK, true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (s1_NotUsed)
            {
                s1_NotUsed = false;
                anim.SetBool(AnimationStates.ANIMATION_SKILL_1, true);
                //start coo
                StartCoroutine(ResetSkills(1));
            }
          
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (s2_NotUsed)
            {
                s2_NotUsed = false;
                anim.SetBool(AnimationStates.ANIMATION_SKILL_2, true);
                //start coo
                StartCoroutine(ResetSkills(2));
            }

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (s3_NotUsed)
            {
                s3_NotUsed = false;
                anim.SetBool(AnimationStates.ANIMATION_SKILL_3, true);
                //start coo
                StartCoroutine(ResetSkills(3));
            }

        }
        
    }

    //SKILL EFFECTS

    //SKILL ONE
    void SkillOne(bool skillOne)
    {
        if (skillOne)
        {
            Instantiate(skillOne_EffectPrefab, skillOne_Point.position, skillOne_Point.rotation);
            audioSource.PlayOneShot(skillOneMusic1);
            StartCoroutine(SkillOneCoroutine());

        }
    }

    void SkillOneSound(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(playerSkillOneSound);
        }
    }

    void SkillOneEnd(bool skillOneEnd)
    {
        if (skillOneEnd)
        {
            anim.SetBool(AnimationStates.ANIMATION_SKILL_1, false);
        }
    }
    IEnumerator SkillOneCoroutine()
    {
        yield return new WaitForSeconds(1.5f);  
        Instantiate(skillOne_DamagePrefab, skillOne_Point_1.position, skillOne_Point_1.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_2.position, skillOne_Point_2.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_3.position, skillOne_Point_3.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_4.position, skillOne_Point_4.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_5.position, skillOne_Point_5.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_6.position, skillOne_Point_6.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_7.position, skillOne_Point_7.rotation);
        Instantiate(skillOne_DamagePrefab, skillOne_Point_8.position, skillOne_Point_8.rotation);
        
    }

    //SKILL TWO

        void SkillTwo(bool skillTwo)
    {
        if (skillTwo)
        {
            Instantiate(skillTwo_EffectPrefab, skillTwo_Point.position, skillTwo_Point.rotation);
            audioSource.PlayOneShot(skillTwoMusic);
            //Start Coo
            StartCoroutine(SkillTwoCoroutine());
        }
    }

    void SKillTwoEnd(bool skillTwoEnd)
    {
        if (skillTwoEnd)
        {
            anim.SetBool(AnimationStates.ANIMATION_SKILL_2, false);
        }
    }

    IEnumerator SkillTwoCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillTwo_DamagePrefab, skillTwo_Point_1.position, skillTwo_Point_1.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwo_Point_2.position, skillTwo_Point_2.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwo_Point_3.position, skillTwo_Point_3.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwo_Point_4.position, skillTwo_Point_4.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwo_Point_5.position, skillTwo_Point_5.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwo_Point_6.position, skillTwo_Point_6.rotation);
       
    }

    //Skill Three
    // SKILL THREE

    void SkillThree(bool skillThree)
    {
        if (skillThree)
        {
            Instantiate(skillThree_EffectPrefab, skillThree_Point_1.position, skillThree_Point_1.rotation);
            Instantiate(skillThree_EffectPrefab, skillThree_Point_2.position, skillThree_Point_2.rotation);
            Instantiate(skillThree_EffectPrefab, skillThree_Point_3.position, skillThree_Point_3.rotation);
            Instantiate(skillThree_EffectPrefab, skillThree_Point_4.position, skillThree_Point_4.rotation);
            Instantiate(skillThree_EffectPrefab, skillThree_Point_5.position, skillThree_Point_5.rotation);
        }
    }

    void SkillThreeEnd(bool skillThreeEnd)
    {
        if (skillThreeEnd)
        {
            anim.SetBool(AnimationStates.ANIMATION_SKILL_3, false);
        }
    }

    public void AttackButtonPressed()
    {
        anim.SetBool(AnimationStates.ANIMATION_ATTACK, true);
    }
    public void AttackButtonRelease()
    {
        anim.SetBool(AnimationStates.ANIMATION_ATTACK, false);
    }

    IEnumerator ResetSkills(int skill)
    {
        yield return new WaitForSeconds(3f);
        switch (skill)
        {
            case 1:
                s1_NotUsed = true;
                break;
            case 2:
                s2_NotUsed = true;
                break;
            case 3:
                s3_NotUsed = true;
                break;

        }
    }

    }//class
