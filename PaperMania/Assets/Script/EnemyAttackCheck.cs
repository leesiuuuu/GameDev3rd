using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    private GameObject Player;
    private Animator animator;
    public GameObject Enemy;
    void Start(){
        Player = GameObject.Find("Player_idel-Sheet_0");
        animator = Enemy.GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player") && Enemy.GetComponent<PlayerAttackEnemy>().Attack && !Player.GetComponent<PlayerMovement>().isSkilled2){
            Player.GetComponent<PlayerAttakced>().enabled = true;
        }
    }
}
