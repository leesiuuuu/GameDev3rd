using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.UIElements;

public class DeathScene : MonoBehaviour
{    
    public GameObject Restart;
    public GameObject Main;
    void Start(){
        DOTween.Init();
        Invoke("BtnEnable", 2f);
    }
    public void ReturnStage(){
        Invoke("ReturnStageCall", 1.2f);
    }
    public void GoMain(){
        Invoke("GOMainCall", 1.2f);
    }
    public void BtnEnable(){
        Restart.SetActive(true);
        Main.SetActive(true);
    }
    private void GOMainCall(){
        Restart.transform.DOScale(new Vector3(0,0,0), 0.8f);
        GameManager.Instance.PlayerHP = 200;
        GameManager.Instance.EnergyBar = 100;
        GameManager.Instance.Paper = 0;
        GameManager.Instance.isStageClear = false;
        GameManager.Instance.isEnd = false;
        SceneManager.LoadScene("Main");
    }
    private void ReturnStageCall(){
        Main.transform.DOScale(new Vector3(0,0,0), 1.2f);
        GameManager.Instance.PlayerHP = 200;
        GameManager.Instance.EnergyBar = 100;
        GameManager.Instance.Paper = 0;
        GameManager.Instance.isStageClear = false;
        GameManager.Instance.isEnd = false;
        switch(GameManager.Instance.StageCount){
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
            case 4:
                SceneManager.LoadScene("Stage4");
                break;
        }
    }
}
