using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEnemy : MonoBehaviour
{
    public float Range = 1.3f;
    public Transform EnemyPos;
    private Animator animator;
    public bool Attack = false;
    
    void Awake(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        Collider2D[] Collider2Ds = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach(Collider2D col in Collider2Ds){
            if(col.gameObject.CompareTag("Player")){
                Attack = true;
                animator.SetBool("Attack", true);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(EnemyPos.position, Range);
    }
    void ResetBool(){
        animator.SetBool("Attack", false);
    }
}
