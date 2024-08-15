using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TalkBalloon : MonoBehaviour
{
    private Animator animator;
    private bool isVisible2;
    private GameObject NPC_Talk1;
    void Start()
    {
        animator = GetComponent<Animator>();
        NPC_Talk1 = GameObject.Find("NPC_Talk1");
        NPC_Talk1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("IDLE", 0.3f);
    }
    void IDLE(){
        NPC_Talk1.SetActive(true);
        animator.SetBool("idle", true); 
    }
}
