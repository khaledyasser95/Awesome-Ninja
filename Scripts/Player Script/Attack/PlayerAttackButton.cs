using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerAttackButton : MonoBehaviour, IPointerDownHandler,IPointerUpHandler {
    private PlayersAttack playerAttack;
    void Awake()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayersAttack>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
       if (gameObject.name== "Attack")
        {
            playerAttack.AttackButtonPressed();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.name == "Attack")
        {
            playerAttack.AttackButtonRelease();
        }
    }
}
