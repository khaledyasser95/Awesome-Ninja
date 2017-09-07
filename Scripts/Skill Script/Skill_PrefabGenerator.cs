using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_PrefabGenerator : MonoBehaviour {

    public GameObject[] skillPrefab;
    private int randNuml;
    public int thisManyTimes = 3;
    public float overThisTime = 3f;

    public float x_Width, y_Width, z_Width;
    public float x_RotMax, y_RotMax=180f, z_RotMax;
    public bool allUseSameRotation = false;
    private bool allRotationDecided = false;

    private float x_Cur, y_Cur, z_Cur;
    private float x_RotCur, y_RotCur, z_RotCur;

    private float timeCounter;
    private float effectCounter;

    private float trigger;
    // Use this for initialization
	void Start () {
		if (thisManyTimes < 1)
        {
            thisManyTimes = 1;
        }
        //Define interval of time
        trigger = overThisTime / thisManyTimes;
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        if (timeCounter>trigger && effectCounter <= thisManyTimes)
        {
            randNuml = Random.Range(0, skillPrefab.Length);

            x_Cur = transform.position.x + (Random.value * x_Width) - (x_Width * 0.5f);
            y_Cur = transform.position.y + (Random.value * y_Width) - (y_Width * 0.5f);
            z_Cur = transform.position.z + (Random.value * z_Width) - (z_Width * 0.5f);

            if (!allUseSameRotation|| !allRotationDecided)
            {
                x_RotCur = transform.position.x + (Random.value * x_RotMax * 2) - (x_RotMax);
                y_RotCur = transform.position.y + (Random.value * y_RotMax * 2) - (y_RotMax);
                z_RotCur = transform.position.z + (Random.value * z_RotMax * 2) - (z_RotMax);
                allRotationDecided = true;
            }
            GameObject skill = Instantiate(skillPrefab[randNuml],new Vector3(x_Cur,y_Cur,z_Cur),transform.rotation);
            skill.transform.Rotate(x_RotCur, y_RotCur, z_RotCur);
            timeCounter -= trigger;
            effectCounter++;
        }
	}
}//class































