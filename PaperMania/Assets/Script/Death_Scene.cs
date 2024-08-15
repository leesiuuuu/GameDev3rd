using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Death_Scene : MonoBehaviour
{
    
    void Start()
    {
        gameObject.transform.DOMoveX(-71.15f, 1f).SetEase(Ease.OutCirc).SetDelay(0.4f);
        gameObject.transform.DOScaleX(-3.28f, 1f).SetEase(Ease.OutCirc).SetDelay(0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
