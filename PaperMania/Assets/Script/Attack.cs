using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Attack : MonoBehaviour
{
    public GameObject AttackEffect;
    public bool EnemyAttacked = false;
    private bool Skilled;
    private GameObject AttackObject;
    public GameObject Player;
    public bool Skill123 = false;
    private bool isAttacked123 = false;
    public bool isSkilled2 = false;
    public float collisionCheckTime = 0.8f;
    public float timer = 0.0f;
    public bool isShield123;
    void Awake(){
    }
    void Update(){
        isShield123  = Player.GetComponent<PlayerMovement>().ShieldCheck;
        Skilled = Player.GetComponent<PlayerMovement>().Skill;
        //평타
        if(EnemyAttacked){
            if(AttackObject.CompareTag("Enemy")){ //슬라임에게 맞췄을 시
                if(!isAttacked123){
                    GameManager.Instance.EnergyBar += 5;
                    isAttacked123 = true;
                }
                DamageAndEffect(0.85f, 4, 20);
                AttackObject.GetComponent<EnemyMovement>().HP -= GameManager.Instance.Damage;
                Debug.Log("HP : " + AttackObject.GetComponent<EnemyMovement>().HP);
            }
            else if(AttackObject.CompareTag("Hunter")){//사냥꾼에게 맞췄을 시
                if(!isAttacked123){
                    GameManager.Instance.EnergyBar += 5;
                    isAttacked123 = true;
                }
                DamageAndEffect(0.85f, 4, 20);
                AttackObject.GetComponent<Hunter>().HP-=GameManager.Instance.Damage;
                Debug.Log("HP : " + AttackObject.GetComponent<Hunter>().HP);
            }
        }
        //스킬1
        if(Skilled && Skill123){
            if(AttackObject.CompareTag("Enemy")){//슬라임에게 맞췄을 시
                DamageAndEffect(1.1f, 8, 40);
                AttackObject.GetComponent<Animator>().SetTrigger("Attacked");
                AttackObject.GetComponent<EnemyMovement>().HP-=GameManager.Instance.SkillDamage;
                Debug.Log("HP : " + AttackObject.GetComponent<EnemyMovement>().HP);
            }
            else if(AttackObject.CompareTag("Hunter")){//사냥꾼에게 맞췄을 시
                DamageAndEffect(1.1f, 8, 40);
                AttackObject.GetComponent<Animator>().SetTrigger("Attacked");
                AttackObject.GetComponent<Hunter>().HP-=GameManager.Instance.SkillDamage;
                Debug.Log("HP : " + AttackObject.GetComponent<Hunter>().HP);
            }
        }
        if(isSkilled2){//방어 스킬을 맞았을 시
            if(AttackObject.CompareTag("Enemy")){//슬라임에게 맞췄을 시
                DamageAndEffect(1.4f, 8, 60);
                AttackObject.GetComponent<Animator>().SetTrigger("Attacked");
                AttackObject.GetComponent<EnemyMovement>().HP-=GameManager.Instance.SKill2Damage;
                Debug.Log("HP : " + AttackObject.GetComponent<EnemyMovement>().HP);
            }
            else if(AttackObject.CompareTag("Hunter")){//사냥꾼에게 맞췄을 시
                DamageAndEffect(1.4f, 8, 60);
                AttackObject.GetComponent<Animator>().SetTrigger("Attacked");
                AttackObject.GetComponent<Hunter>().HP-=GameManager.Instance.SKill2Damage;
                Debug.Log("HP : " + AttackObject.GetComponent<Hunter>().HP);
            }
        }
        if(isShield123){
            timer += Time.deltaTime;
            if(timer >= collisionCheckTime){
                Player.GetComponent<PlayerMovement>().ShieldCheck = false;
                Player.GetComponent<PlayerMovement>().isSkilled2 = false;
                timer = 0.0f;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision2D){
        isSkilled2 = false;
        if(!Player.GetComponent<PlayerMovement>().ShieldCheck){
            if(collision2D.gameObject.CompareTag("Enemy")){ //슬라임을 공격했을 시
                if(Skilled && !Skill123){ //스킬을 맞췄을 시
                    Skill123 = true;
                    Invoke("SkillFalse", 0.1f);
                }
                else { // 평타를 맞췄을 시
                    EnemyAttacked = true;
                    isAttacked123 = false;
                    Invoke("EnemyAttackedFalse", 0.1f);
                }
                AttackObject = collision2D.gameObject;
                GameObject EffectClone = Instantiate(AttackEffect);
                ContactPoint2D contact = collision2D.contacts[0];
                Vector3 pos = contact.point;
                EffectClone.transform.position = new Vector3(pos.x, pos.y, 18.5f);
                Destroy(EffectClone, 0.2f);
            }
            else if(collision2D.gameObject.CompareTag("Hunter")){//사냥꾼을 공격했을 시
                    if(Skilled && !Skill123){//스킬을 맞췄을 시
                        Skill123 = true;
                        Invoke("SkillFalse", 0.1f);
                    }
                    else {// 평타를 맞췄을 시
                        EnemyAttacked = true;
                        isAttacked123 = false;
                        Invoke("EnemyAttackedFalse", 0.1f);
                    }
                    AttackObject = collision2D.gameObject;
                    GameObject EffectClone = Instantiate(AttackEffect);
                    ContactPoint2D contact = collision2D.contacts[0];
                    Vector3 pos = contact.point;
                    EffectClone.transform.position = new Vector3(pos.x, pos.y, 18.5f);
                    Destroy(EffectClone, 0.2f);
                }
        }
        else if(Player.GetComponent<PlayerMovement>().ShieldCheck){
            if(collision2D.gameObject.CompareTag("Enemy")){
                Player.GetComponent<Animator>().SetTrigger("IsShielded");
                Player.GetComponent<PlayerMovement>().ShieldCheck = false;
                Invoke("Skill2True", 0.1f);
                Invoke("Skill2False", 1.0f);
            }
            else if(collision2D.gameObject.CompareTag("EnemyAtkCol")){
                Player.GetComponent<Animator>().SetTrigger("IsShielded");
                Player.GetComponent<PlayerMovement>().ShieldCheck = false;
                Invoke("Skill2True", 0.1f);
                Invoke("Skill2False", 1.0f);
            }
        }
    }
    void EnemyAttackedFalse(){
        EnemyAttacked = false;
    }
    void SkillFalse(){
        Skill123 = false;
        Player.GetComponent<PlayerMovement>().Skill = false;
    }
    void Skill2False(){
        isSkilled2 = false;
        Player.GetComponent<PlayerMovement>().isSkilled2 = false;
    }
    void Skill2True(){
        isSkilled2 = true;
    }
    void DamageAndEffect(float Speed1, int Vibrato1, float Randomness){
        AttackObject.transform.position += (AttackObject.transform.localScale.x > 0 ? Vector3.right : Vector3.left) * Speed1;
        if(AttackObject.transform != null){
            AttackObject.transform.DOShakePosition(0.2f, 0.3f, Vibrato1, Randomness, false, true, ShakeRandomnessMode.Full);
        }
        AttackObject.GetComponent<Animator>().SetTrigger("Attacked");
    }
}
