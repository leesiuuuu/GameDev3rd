using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject isReallyWindow;
    public GameObject Script;
    public static bool isGamePause = false;
    public static bool ReallyMain = false;
    private RectTransform WinPos;
    void Awake(){
        //DontDestroyOnLoad(gameObject);
        DOTween.Init();
        WinPos = isReallyWindow.GetComponent<RectTransform>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Script.GetComponent<GameStart>().Started){
            if(isGamePause){
                Resume();
            }
            else{
                Paused();
            }
        }
    }
    public void Paused(){
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0;
        isGamePause = true;
    }
    public void Resume(){
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1;
        isGamePause = false;
    }
    public void ToMain(){
        Debug.Log("메인 불러와짐!");
        SceneManager.LoadScene("Main");
    }
    public void ReallyMainGo(){
        Debug.Log("ReallyMainGo called");
        WinPos.DOAnchorPos(new Vector3(0,0,0), 0.7f)
              .SetEase(Ease.OutCirc)
              .SetUpdate(true);
    }
    public void ReallyYes(){
        Time.timeScale = 1;
        Invoke("ToMain", 1.5f);
    }
    public void NoNigga(){
        Debug.Log("NoNigga called");
        WinPos.DOAnchorPos(new Vector3(0,850,0), 0.7f)
              .SetEase(Ease.OutCirc)
              .SetUpdate(true);
    }
}
