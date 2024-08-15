using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Transform Transform;
    private Rigidbody2D Rigidbody;
    public Transform EnemyPos;
    private Animator animator;
    public float Range = 5f;
    public float Speed = 5f;
    public bool ScaleTransform = false;
    public bool SquishedTrigger;
    public bool isAttacked = false;
    public float HP = 50;
    public float SlowSpeed = 1f;
    public bool Slowed = false;
    private GameObject Player;
    private GameObject PlayerAtkCol;
    public GameObject DeathEffect;
    private ItemDrop itemDrop;
    private bool isItemDrop = false;
    private HPBar hPBar;
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        PlayerAtkCol = GameObject.FindWithTag("PlayerAtkCol");
        itemDrop = GetComponent<ItemDrop>();
        hPBar = GetComponent<HPBar>();
        hPBar.Enemy = gameObject;
        isAttacked = PlayerAtkCol.GetComponent<Attack>().EnemyAttacked;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] Collider2Ds = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach (Collider2D col in Collider2Ds)
        {
            Vector3 moveVelocity = Vector3.zero;
            if (col.gameObject.CompareTag("Player"))
            {
                Vector3 direction = col.transform.position - transform.position;
                direction.Normalize();
                if(direction.y <= 0.4f){
                    if (direction.x > 0)
                    {
                        transform.localScale = new Vector3(-1.58f, transform.localScale.y, 1.58f);
                        moveVelocity = Vector3.right;
                    }
                    if (direction.x < 0)
                    {
                        transform.localScale = new Vector3(1.58f, transform.localScale.y, 1.58f);
                        moveVelocity = Vector3.left;
                    }
                }
                if(direction.x > -1f && direction.x < 1f){
                    moveVelocity = transform.localScale.x > 1 ? Vector3.left : Vector3.right;
                }
                transform.position += moveVelocity * Speed * Time.deltaTime * SlowSpeed;
            }
        }
        if (ScaleTransform)
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.54f, transform.localScale.z);
            ScaleTransform = false;
            hPBar.DestroyHPBar(gameObject);
            Destroy(gameObject, 0.2f);
        }
        if (SquishedTrigger) //밟힘 로직
        {
            animator.SetTrigger("Squished");
            SquishedTrigger = false;
        }
        if(transform.position.z != 19){
            transform.position = new Vector3(transform.position.x, transform.position.y, 19f);
        }
        
        if(HP <= 0 && !isItemDrop){
            isItemDrop = true;
            Invoke("Death", 0.1f);
            itemDrop.DropItems();
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(EnemyPos.position, Range);
    }
    void Death(){
        GameObject clone = Instantiate(DeathEffect);
        clone.transform.position = new Vector3(EnemyPos.position.x, EnemyPos.position.y, 19);
        hPBar.DestroyHPBar(gameObject);
        Destroy(this.gameObject);
        Destroy(clone, 0.2f);
    }
}
