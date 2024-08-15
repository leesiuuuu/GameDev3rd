using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AttackKey : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private int AnimationCount = 1;
    private bool FirstAttack = false;
    private bool AttackAnimation = false;
    private static readonly int JumpStateHash = Animator.StringToHash("Base Layer.Attack");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.fullPathHash == JumpStateHash)
        {
            AttackAnimation = true;
        }
        else
        {
            AttackAnimation = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && !AttackAnimation && !Pause.isGamePause)
        {
            if (!FirstAttack && AnimationCount == 1)
            {
                animator.SetTrigger("Attack");
                animator.ResetTrigger("IsNextCombo");
                AnimationCount++;
                FirstAttack = true;
            }
            else if (FirstAttack && AnimationCount == 2)
            {
                animator.ResetTrigger("Attack");
                animator.SetTrigger("IsNextCombo");
                AnimationCount++;
                FirstAttack = false;
            }
            else
            {
                animator.ResetTrigger("IsNextCombo");
                animator.ResetTrigger("Attack");
                FirstAttack = false;
                AnimationCount = 1;
            }
        }
    }
    public void AnimationEnd()
    {
        AnimationCount = 1;
        FirstAttack = false;
    }
}
