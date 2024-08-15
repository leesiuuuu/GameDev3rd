using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image barImage1;
    public Image SkillBarImage;
    private float HP1;
    private float SkillBar;
    void Update(){
        HP1 = GameManager.Instance.PlayerHP;
        SkillBar = GameManager.Instance.EnergyBar;
        ChangeHPbarAmount(HP1);
        ChangeSkillBarAmount(SkillBar);
    }
    private void ChangeHPbarAmount(float amount){
        barImage1.fillAmount = amount * 0.01f / 2;
    }
    private void ChangeSkillBarAmount(float amount){
        SkillBarImage.fillAmount = amount * 0.01f;
    }
}
