using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    private enum State{
        isRobot,
        PlayerHere,
        PlayerLeft,
        FPressed,
        Rolling,
        ItemReturn,
        RobotReset
    }
    public int RandomNum;
    public LayerMask PlayerMask;
    private State state;
    public List<GameObject> ItemList = new List<GameObject>(4);
    public float range;
    public bool ItemOnce = false;
    private bool ItemReturn1 = false;
    public GameObject alarm;
    public GameObject FKey;
    private GameObject ReturnItem;
    private Animator animator;
    void Start()
    {
        if(GameManager.Instance.isRobot && !GameManager.Instance.isPoro){
            state = State.isRobot;
            animator = GetComponent<Animator>();
            alarm.SetActive(false);
            FKey.SetActive(false);
            if(ItemOnce){
                ItemOnce = false;
            }
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case State.isRobot:
                isRobot();
                break;
            case State.PlayerHere:
                state = State.FPressed;
                break;
            case State.PlayerLeft:
                break;
            case State.FPressed:
                FPressed();
                break;
            case State.ItemReturn:
                ItemReturn(ReturnItem);
                break;
        }
    }
    void isRobot(){
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range, PlayerMask);
        if(cols.Length == 0){
            alarm.SetActive(true);
            FKey.SetActive(false);
        }
        else{
            alarm.SetActive(false);
            FKey.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F) && !ItemReturn1){
            foreach(Collider2D colss in cols){
                state = State.PlayerLeft;
                if(colss.gameObject.CompareTag("Player")){
                    state = State.PlayerHere;
                    break;
                }
            }            
        }

    }
    void FPressed(){

        RandomNum = Random.Range(1, 101);
        alarm.SetActive(false);
        FKey.SetActive(false);
        animator.SetBool("Shake", true);
        Invoke("ItemReturnStart", 1.5f);
    }
    void ItemReturnStart(){
        animator.SetBool("Shake", false);
        state = State.ItemReturn;
    }
    void ItemReturn(GameObject ReturnItem1){
        if(RandomNum > 0 && RandomNum < 6){
            ReturnItem1 = ItemList[3];
        }
        else if(RandomNum > 7 && RandomNum < 18){
            ReturnItem1 = ItemList[2];
        }
        else if(RandomNum > 19 && RandomNum < 50){
            ReturnItem1 = ItemList[1];
        }
        else{
            ReturnItem1 = ItemList[0];
        }
        if(!ItemOnce){
            GameObject Item = Instantiate(ReturnItem1, transform.position, Quaternion.identity);
            ItemReturn1 = true;
            ItemOnce = true;      
        }
        RandomNum = 0; 

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
