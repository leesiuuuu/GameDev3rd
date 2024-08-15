using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float PlayerHP = 200;
    public float EnergyBar = 100;
    public float Paper = 0;
    public int StageCount = 1;
    public float Damage = 1;
    public float SkillDamage = 2;
    public float SKill2Damage = 4;
    public float Skill1CoolTime = 2f;
    public float Skill2CoolTime = 3f;
    public List<GameObject> ItemList = new List<GameObject>(2);
    public float SlowSpeed = 1;
    public float Speed = 1;
    public bool isStageClear = false;
    public bool isEnd = false;
    public int isRobot = 10;
    public int isPoro = 10;
    public GameObject PaperShield;
    public GameObject HotPack;
    public GameObject RandomBox;
    public GameObject EraserPowder;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ItemList.Add(null);
            ItemList.Add(null);
        }
        else
        {
            Debug.Log("인스턴스 두개임!");
            Destroy(gameObject);
        }
    }
    void Update(){
        if(!GameObject.FindWithTag("Enemy") && !GameObject.FindWithTag("Hunter") && !isEnd){
            isStageClear = true;
        }
        if(PlayerHP <= 0){
            SceneManager.LoadScene("DeathScene");
            PlayerHP = 1;
        }
    }
    public void isStageAndEndReset(){
        isStageClear = false;
        isEnd = false;
        StageCount++;
    }
    public void StageCome(){
        if(StageCount != 1){
            isPoro = UnityEngine.Random.Range(1, 11);
            isRobot = UnityEngine.Random.Range(1, 11);
            if(isRobot >= 7){
                isPoro = 0;
            }
            else if(isPoro % 2 != 0){
                isRobot = 0;
            }
        }
    }
    public void ItemAdd(GameObject Item){
            Debug.Log("Item Added! Item Name : " + Item.name);
            if(Item.name == "EraserPowder(Clone)"){
                ItemList[ItemList[0] != null ? 1 : 0] = (EraserPowder);
            }
            else if(Item.name == "HotPack(Clone)"){
                ItemList[ItemList[0] != null ? 1 : 0] = (HotPack);
            }
            else if(Item.name == "PancilShield(Clone)"){
                ItemList[ItemList[0] != null ? 1 : 0] = (PaperShield);
            }
            else{
                ItemList[ItemList[0] != null ? 1 : 0] = (RandomBox);
            }
    }
    public void ItemPlus(Image Item){
        for(int i = 0; i < ItemList.Count; i++){
            if(GameManager.Instance.ItemList[i] == null){
                Item.sprite = GameManager.Instance.ItemList[i].GetComponent<SpriteRenderer>().sprite;
                break;
            }            
        }
    }
}
