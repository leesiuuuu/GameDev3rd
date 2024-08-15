using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StageUIShowAndClose", 1.2f);
    }

    void StageUIShowAndClose(){
        RectTransform Pos = GetComponent<RectTransform>();
        Pos.DOAnchorPos(new Vector2(0,345), 0.8f).SetEase(Ease.OutBounce);
        Pos.DOAnchorPos(new Vector2(0,700), 0.8f).SetEase(Ease.OutCirc).SetDelay(2.4f);
        Destroy(gameObject, 7f);
    }
}
