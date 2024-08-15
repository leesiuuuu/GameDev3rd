using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyColliderCheck : MonoBehaviour
{
    public GameObject Enemy;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y < -0.5f){
            Enemy.GetComponent<EnemyMovement>().ScaleTransform = true;
            Enemy.GetComponent<EnemyMovement>().SquishedTrigger = true;
        }
    }
}
