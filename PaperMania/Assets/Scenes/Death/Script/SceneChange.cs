using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChange : MonoBehaviour
{
    public void SceneFade(){
        gameObject.GetComponent<Image>().DOColor(new Color(0,0,0,1), 1.2f);
    }
}
