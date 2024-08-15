using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPaperUI : MonoBehaviour
{
    public Image barImage1;
    private float Paper;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Paper = GameManager.Instance.Paper;
        ChangePaperbarAmount(Paper);
    }
    private void ChangePaperbarAmount(float amount){
        barImage1.fillAmount = amount * 0.04f;
    }
}
