using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GO : MonoBehaviour
{
    public GameObject go;
    public GameObject Canvas;
    private RectTransform GO1;
    public bool Once = false;
    GameObject Go;
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Go = Instantiate(go, Canvas.transform);
        Go.name = "Go";
        GO1 = Go.GetComponent<RectTransform>();
        Go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isStageClear && !GameManager.Instance.isEnd){
            if(!Once){
                Go.SetActive(true);
                Once = true;
                Go.GetComponent<DOTweenAnimation>().DOPlay();
            }
        }
        if(GameManager.Instance.isEnd){
            Destroy(Go);
        }
    }
}
