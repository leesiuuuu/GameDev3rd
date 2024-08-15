using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAndReset(){
        GameManager.Instance.PlayerHP = 200;
        GameManager.Instance.EnergyBar = 100;
        GameManager.Instance.Paper = 0;
        GameManager.Instance.StageCount = 1;
        GameManager.Instance.Damage = 1;
        GameManager.Instance.SkillDamage = 2;
        GameManager.Instance.SKill2Damage = 4;
        GameManager.Instance.Skill1CoolTime = 2f;
        GameManager.Instance.Skill2CoolTime = 3f;
        GameManager.Instance.SlowSpeed = 1;
        GameManager.Instance.Speed = 1;
        GameManager.Instance.isStageClear = false;
        GameManager.Instance.isEnd = false;
        GameManager.Instance.isRobot = 10;
        GameManager.Instance.isPoro = 10;
    }
}
