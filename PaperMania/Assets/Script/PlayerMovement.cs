using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Principal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpPower = 1f;
    public Transform PlayerBottomPosition;
    public GameObject JumpEffect;
    public GameObject SlowEffect;
    public GameObject SceneManager;
    private List<EnemyMovement> slowedEnemies = new List<EnemyMovement>();
    private Rigidbody2D rigidbody;
    private Animator animator;
    Vector3 movement;
    bool isJumping = false;
    bool Jumping = false;
    public bool Skill = false;
    public bool SkillCool = false;
    public bool ShieldCool = false;
    public bool ShieldCheck = false;
    public GameObject Enemy;
    public bool BombAtked = false;
    public bool isSkilled2 = false;
    public GameObject Shield;
    public GameObject Volume;
    public Vector2 Size;
    public LayerMask EnemyLayer;
    //public GameObject Volume;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GetComponent<PlayerAttakced>().enabled = false;
        GetComponent<PlayerAutomove>().enabled = false;
        SlowEffect.SetActive(false);
        Shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && !Jumping && !isSkilled2){
            isJumping = true;
            animator.SetTrigger("Jump");
        }
        if(GetComponent<PlayerAttakced>().enabled){
            if(!BombAtked){
                Volume.GetComponent<VolumeSetting>().enabled = true;
                GameManager.Instance.PlayerHP -= EnemyManager.Instance.EnemyDamage;
                Invoke("ResetAttackedScript", 0.1f);
                Invoke("SlowReturn", 2f);
            }
            else{
                Volume.GetComponent<VolumeSetting>().enabled = true;
                GameManager.Instance.PlayerHP -= EnemyManager.Instance.EnemyDamage * 0.8f;
                GameManager.Instance.SlowSpeed = 0.5f;
                SlowEffect.SetActive(true);
                Invoke("ResetAttackedScript_Bomb", 0.1f);
            }
        }
        if(Input.GetKeyDown(KeyCode.A) && !isSkilled2 && !Pause.isGamePause){
            if(!SkillCool && GameManager.Instance.EnergyBar > 20){
                animator.SetTrigger("Skill");
                Skill = true;
                SkillCool = true;
                GameManager.Instance.EnergyBar -= 20;
                Invoke("SkillCool1", GameManager.Instance.Skill1CoolTime);
            }
            else{
                Debug.Log("스킬 쿨타임! 또는 기력 부족!");
            }
        }
        if(Input.GetKeyDown(KeyCode.C) && !Pause.isGamePause){
            if(!ShieldCool && GameManager.Instance.EnergyBar > 30){
                animator.SetTrigger("Skill2");
                ShieldCheck = true;
                ShieldCool = true;
                isSkilled2 = true;
                GameManager.Instance.EnergyBar -= 30;
                Invoke("ShieldCool1", GameManager.Instance.Skill2CoolTime);
            }
            else{
                Debug.Log("스킬 쿨타임! 또는 기력 부족!");
            }
        }
        if(GameManager.Instance.PlayerHP > 200){
            GameManager.Instance.PlayerHP = 200;
        }
        if(GameManager.Instance.Paper >= 25){
            if(GameManager.Instance.PlayerHP <= 160){
                GameManager.Instance.PlayerHP += 40;
                GameManager.Instance.Paper = 0;
            }
            else if(GameManager.Instance.PlayerHP > 160){
                GameManager.Instance.PlayerHP = 200;
                GameManager.Instance.Paper = 0;
            }
        }
        if(GameManager.Instance.EnergyBar > 100){
            GameManager.Instance.EnergyBar = 100;
        }
        if(GameManager.Instance.isEnd){
            SceneManager.SetActive(true);
            GetComponent<PlayerAutomove>().enabled = true;
        }
        // 아이템 적용
        if(Input.GetKeyDown(KeyCode.S)){
            if(GameManager.Instance.ItemList[0].gameObject.name == "EraserPowder"){
                //아이템 있을 시 실행
                StartCoroutine(EraserSkillDuring(4f));
                GameManager.Instance.ItemList.RemoveAt(0);
                GameManager.Instance.ItemList.Insert(0, null);
                Debug.Log("Coroutine is End!");
            }
            else if(GameManager.Instance.ItemList[0].gameObject.name == "HotPack"){
                StartCoroutine(HotPackDuring(10));
                GameManager.Instance.ItemList.RemoveAt(0);
                GameManager.Instance.ItemList.Insert(0, null);
                Debug.Log("Coroutine is End!");
            }
            else if(GameManager.Instance.ItemList[0].gameObject.name == "PancilShield"){
                StartCoroutine(PencilShieldDuring(20));
                GameManager.Instance.ItemList.RemoveAt(0);
                GameManager.Instance.ItemList.Insert(0, null);
                Debug.Log("Coroutine is End!");
            }
            else if(GameManager.Instance.ItemList[0].gameObject.name == "RandomBox"){
                StartCoroutine(RandomBoxDuring(20, false));
                GameManager.Instance.ItemList.RemoveAt(0);
                GameManager.Instance.ItemList.Insert(0, null);
                Debug.Log("Coroutine is End!");
            }
            else{
                Debug.Log("Item is Null!");
            }
        }
        if(Input.GetKeyDown(KeyCode.D)){
            if(GameManager.Instance.ItemList[1].gameObject.name == "EraserPowder"){
                //아이템 있을 시 실행
                StartCoroutine(EraserSkillDuring(4f));
                GameManager.Instance.ItemList.RemoveAt(1);
                GameManager.Instance.ItemList.Insert(1, null);
                Debug.Log("Coroutine is End!");
            }
            else if(GameManager.Instance.ItemList[1].gameObject.name == "HotPack"){
                StartCoroutine(HotPackDuring(10));
                GameManager.Instance.ItemList.RemoveAt(1);
                GameManager.Instance.ItemList.Insert(1, null);
                Debug.Log("Coroutine is End!");
            }
            else if(GameManager.Instance.ItemList[1].gameObject.name == "PancilShield"){
                StartCoroutine(PencilShieldDuring(20));
                GameManager.Instance.ItemList.RemoveAt(1);
                GameManager.Instance.ItemList.Insert(1, null);
                Debug.Log("Coroutine is End!");
            }
            else if(GameManager.Instance.ItemList[1].gameObject.name == "RandomBox"){
                StartCoroutine(RandomBoxDuring(20, false));
                GameManager.Instance.ItemList.RemoveAt(1);
                GameManager.Instance.ItemList.Insert(1, null);
                Debug.Log("Coroutine is End!");
            }
            else{
                Debug.Log("Item is Null!");
            }
        }
        CheckEnemiesInRange();
    }
    IEnumerator RandomBoxDuring(float During, bool RandomOnce){
        int RandomNum = 0;
        if(!RandomOnce){
            RandomNum = UnityEngine.Random.Range(1, 101);
            RandomOnce = true;
        }
        if(RandomOnce){
            if(RandomNum > 0 && RandomNum <=30){
                Debug.Log("CoolTime Low!");
                GameManager.Instance.Skill1CoolTime /= 2;
                GameManager.Instance.Skill2CoolTime /= 2;
            }
            else if(RandomNum > 30 && RandomNum <= 70){
                Debug.Log("Speed Up!");
                GameManager.Instance.Speed *= 1.3f;
            }
            else if(RandomNum > 70 && RandomNum <= 90){
                Debug.Log("Damage Up!");
                GameManager.Instance.Damage *= 2;
            }
            else{
                Debug.Log("Skill Damage Up!");
                GameManager.Instance.SkillDamage *= 2;
            }
        }
        yield return new WaitForSeconds(During);
            if(RandomNum > 0 && RandomNum <=30){
                GameManager.Instance.Skill1CoolTime *= 2;
                GameManager.Instance.Skill2CoolTime *= 2;
            }
            else if(RandomNum > 30 && RandomNum <= 70){
                GameManager.Instance.Speed /= 1.3f;
            }
            else if(RandomNum > 70 && RandomNum <= 90){
                GameManager.Instance.Damage /= 2;
            }
            else{
                GameManager.Instance.SkillDamage /= 2;
            }
        RandomNum = 0;
    }

    //연필 방패(일시적 적 공격 방어) 구현 함수
    IEnumerator PencilShieldDuring(float During){
        Shield.SetActive(true);
        yield return new WaitForSeconds(During * 0.6f);
        SpriteRenderer SR = Shield.GetComponent<SpriteRenderer>();
        for(int i = 0; i < 4; i++){
            yield return SR.DOFade(0, 0.5f).WaitForCompletion();
            yield return SR.DOFade(1, 0.5f).WaitForCompletion();
        }
        Shield.SetActive(false);
    }
    //핫팩(공격력 증가) 구현 함수
    IEnumerator HotPackDuring(float During){
        GameManager.Instance.SkillDamage *= 2;
        GameManager.Instance.SKill2Damage *= 2;
        GameManager.Instance.Damage *= 2;
        yield return new WaitForSeconds(During);
        GameManager.Instance.SkillDamage /= 2;
        GameManager.Instance.SKill2Damage /= 2;
        GameManager.Instance.Damage /= 2;
    }
    //지우개 가루(적 이속 감소) 구현 함수
    IEnumerator EraserSkillDuring(float During){
        Debug.Log("Coroutine is Running!");
        Collider2D[] SlowRange = Physics2D.OverlapBoxAll(PlayerBottomPosition.position, Size, 0);
        foreach(Collider2D cols in SlowRange){
            if(cols.gameObject.CompareTag("Enemy")){
                // EnemyMovement 컴포넌트가 있는지 확인
                EnemyMovement EM = cols.transform.parent.gameObject.GetComponent<EnemyMovement>();
                if(EM != null) {
                    EM.SlowSpeed = 0.5f;
                    EM.Slowed = true;
                    slowedEnemies.Add(EM);
                } else {
                    Debug.LogWarning("The Object had EnemyMovement Couldn't find! :" + cols.gameObject.name);
                }
            }
        }   
        yield return new WaitForSeconds(During);
        foreach(EnemyMovement EM in slowedEnemies){
            if(EM != null && EM.Slowed){
                EM.SlowSpeed = 1f;
                EM.Slowed = false;
            }
        }
        slowedEnemies.Clear();
    }
    //오버랩 범위 밖으로 나갔을 시 속도 원상복구 함수
    void CheckEnemiesInRange(){
        Collider2D[] currentRange = Physics2D.OverlapBoxAll(PlayerBottomPosition.position, Size, 0);
        List<EnemyMovement> enemiesInCurrentRange = new List<EnemyMovement>();
        foreach(Collider2D cols in currentRange){
            if(cols.gameObject.CompareTag("Enemy")){
                EnemyMovement EM = cols.transform.parent.gameObject.GetComponent<EnemyMovement>();
                if (EM != null) {
                    enemiesInCurrentRange.Add(EM);
                }
            }
        }
        for (int i = slowedEnemies.Count - 1; i >= 0; i--) {
        EnemyMovement EM = slowedEnemies[i];
            if (EM != null && !enemiesInCurrentRange.Contains(EM)) {
                EM.SlowSpeed = 1f;  // 원래 속도로 복원
                EM.Slowed = false;
                slowedEnemies.RemoveAt(i);
            }
        }
    }
    void SkillCool1(){
        SkillCool = false;
    }
    void ShieldCool1(){
        ShieldCool = false;
    }
    void FixedUpdate(){
        Move();
        Jump();
    }
    void Move(){
        Vector3 moveVelocity = Vector3.zero;
        if(Input.GetKey(KeyCode.LeftArrow) && !isSkilled2){
            transform.localScale = new Vector3(-1, 1, 1);
            moveVelocity = Vector3.left;
            animator.SetBool("Walking", true);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && !isSkilled2){
            transform.localScale = new Vector3(1, 1, 1);
            moveVelocity = Vector3.right;
            animator.SetBool("Walking", true);
        }
        else{
            animator.SetBool("Walking", false);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime * GameManager.Instance.SlowSpeed * GameManager.Instance.Speed;
    }
    void Jump(){
        if(!isJumping){
            return;
        }
        JumpEffectAdd();
        Jumping = true;
        rigidbody.velocity = Vector3.zero;
        Vector3 jumpVelocity = new Vector3(0, jumpPower, 19f);
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
        isJumping = false;
    }
    void OnCollisionEnter2D(Collision2D collision){
        switch(collision.gameObject.tag){
            case "Ground":
                Jumping = false;
                Debug.Log("땅닿음");
                break;
            case "Enemy":
                Jumping = false;
                break;
        }
    }
    void JumpEffectAdd(){
        GameObject clone = Instantiate(JumpEffect);
        clone.transform.position = PlayerBottomPosition.position;
        Destroy(clone, 0.3f);
    }
    void ResetAttackedScript(){
        GetComponent<PlayerAttakced>().enabled = false;
        if(Enemy != null){
            Enemy.GetComponent<PlayerAttackEnemy>().Attack = false;
            Enemy.GetComponent<Animator>().SetBool("Attack", false);
        }
    }
    void ResetAttackedScript_Bomb(){
        GetComponent<PlayerAttakced>().enabled = false;
        BombAtked = false;
    }
    void SlowReturn(){
        Debug.Log("Slow보구언");
        SlowEffect.SetActive(false);
        GameManager.Instance.SlowSpeed = 1f;
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(PlayerBottomPosition.position, Size);
    }
}
