using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class PaperAndItem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrust;
    private bool nu1 = false;
    private Transform Player;
    private float coneAngle = 90;
    private Vector2 Direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player").transform;
        Direction = GetRandomConeDirection();
    }
    void Update(){
        Player = GameObject.FindWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if(!nu1){
            rb.AddForce(Direction *thrust, ForceMode2D.Impulse);
            Invoke("Return1", 0.2f);            
        }

    }
    void Return1(){
        nu1 = true;
        Invoke("FollowPlayer", 0.2f);
    }
    void FollowPlayer(){
        rb.velocity = Vector3.zero;
        DOTween.To(() => transform.position, x => transform.position = x, Player.position, 1.5f).SetEase(Ease.OutBack);
    }
    Vector2 GetRandomConeDirection()
    {
        // 중심 축을 기준으로 양쪽으로 coneAngle/2 만큼의 범위 내에서 각도를 무작위로 생성
        float angle = Random.Range(-coneAngle / 2, coneAngle / 2);
        // 각도를 라디안으로 변환
        float angleRad = angle * Mathf.Deg2Rad;
        // 벡터 계산 (y축 기준)
        return new Vector2(Mathf.Sin(angleRad), Mathf.Cos(angleRad)).normalized;
    }
    void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.gameObject.CompareTag("Player")){
            GameManager.Instance.Paper++;
            Destroy(gameObject);
        }
    }
}
