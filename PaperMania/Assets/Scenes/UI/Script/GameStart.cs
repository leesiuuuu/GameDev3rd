using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public bool Started = false;
    public void SGtart(){
        if(GameObject.Find("GameManager")){
            GameManager.Instance.PlayerHP = 200;
            GameManager.Instance.EnergyBar = 100;
            GameManager.Instance.Paper = 0;
            GameManager.Instance.StageCount = 1;
            GameManager.Instance.Damage = 1;
            GameManager.Instance.SkillDamage = 2;
            GameManager.Instance.SKill2Damage = 4;
            GameManager.Instance.Skill1CoolTime = 2f;
            GameManager.Instance.Skill2CoolTime = 3f;
            GameManager.Instance.SlowSpeed = 1;
            GameManager.Instance.Speed = 1;
            GameManager.Instance.isStageClear = false;
            GameManager.Instance.isEnd = false;
            GameManager.Instance.isRobot = 10;
            GameManager.Instance.isPoro = 10;            
        }
        Invoke("ddd", 1.2f);
    }
    void ddd(){
        SceneManager.LoadScene("Stage1");
    }
    public void SGEnd(){
        Application.Quit();
    }
    void Start(){
        GameObject.Find("MySceneManager").GetComponent<SceneChanger>().StartSz();
        GameManager.Instance.StageCome();
        GameObject.Find("ItemBG").GetComponent<ItemInventoryUI>().InvenStart();
        Invoke("Returnd", 1.5f);
    }
    void Returnd(){
        Started = true;
    }
}

