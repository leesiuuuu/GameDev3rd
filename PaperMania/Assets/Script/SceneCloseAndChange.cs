using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneCloseAndChange : MonoBehaviour
{
    public bool Once = false;
    public bool twice = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isStageClear && GameManager.Instance.isEnd){
            if(!Once){
                GetComponent<SceneChanger>().StartEd();
                Once = true;
            }
            Invoke("EndScene", 1.5f);
        }
    }
    void EndScene(){
        GameManager.Instance.isStageAndEndReset();
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
        }
        Once = false;
    }
    void MainReturn(){
        SceneManager.LoadScene("Main");
    }
}
