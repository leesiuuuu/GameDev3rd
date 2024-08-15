using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public RectTransform RT;
    public void StartSz(){
        RT.DOSizeDelta(new Vector2(2500, 2500), 0.7f).SetEase(Ease.InCirc).SetDelay(0.8f);
        Invoke("de", 1.5f);
    }
    void de(){
        gameObject.SetActive(false);
    }
    public void StartEd(){ //화면을 검게 (화면 끝)
        gameObject.SetActive(true);
        RT.DOSizeDelta(new Vector2(0, 0), 0.7f).SetEase(Ease.InCirc).SetUpdate(true);
    }
    public void EndEd(){ //화면을 밝게 (화면 시작)
        gameObject.SetActive(true);
        RT.DOSizeDelta(new Vector2(2500, 2500), 0.7f).SetEase(Ease.InCirc).SetUpdate(true);
        Invoke("de", 0.7f);
    }

}
