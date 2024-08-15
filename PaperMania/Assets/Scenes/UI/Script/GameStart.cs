using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public bool Started = false;
    public void SGtart(){
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
        Invoke("Returnd", 1.5f);
    }
    void Returnd(){
        Started = true;
    }
}

