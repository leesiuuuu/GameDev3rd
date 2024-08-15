using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShieldCool : MonoBehaviour
{
    private GameObject Player;
    private Image SkillImage;
    private bool Start1 = false;
    public float CoolTime;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        SkillImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SkillImage.fillAmount == 1){
            Start1 = false;
        }
        if(Player.GetComponent<PlayerMovement>().ShieldCool && !Start1){
            StartCoroutine(SkillCool1(CoolTime));
        }
    }
    private IEnumerator SkillCool1(float waitTime){
        if(!Start1){
            SkillImage.fillAmount = 0;
            Start1 = true;
        }
        while (SkillImage.fillAmount < 1)
        {
            SkillImage.fillAmount += 1 * Time.deltaTime / waitTime;
            yield return null;
        }
        Start1 = false;
        yield break;
    }
}
