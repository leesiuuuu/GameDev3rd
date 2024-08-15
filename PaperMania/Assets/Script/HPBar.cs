using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public GameObject preHpBar;
    private GameObject Canvas;
    private GameObject playerAtkCol;
    private float HP;
    private Transform barImage;
    private Image barImage1;
    GameObject hpBar;
    RectTransform hpBar1;
    DestroyHPBar destroyHPBar;
    public GameObject Enemy;
    void Start()
    {
        playerAtkCol = GameObject.FindWithTag("PlayerAtkCol");
        Canvas = GameObject.Find("Canvas");
        hpBar = Instantiate(preHpBar, Canvas.transform);
        barImage = hpBar.transform.Find("Hpbar");
        hpBar1 = hpBar.GetComponent<RectTransform>();
        if(barImage != null){
            barImage1 = barImage.GetComponent<Image>();
        }
        hpBar.SetActive(false);
        destroyHPBar = barImage1.GetComponent<DestroyHPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        HP = GetComponent<EnemyMovement>().HP;
        Vector3 _hpBarPos =
        Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0.5f, 0.8f, 0));
        if(hpBar1 != null){ 
            hpBar1.position = _hpBarPos;
        }
        if(playerAtkCol.GetComponent<Attack>().EnemyAttacked){
            ChangeHPbarAmount(HP);
        }
        if(playerAtkCol.GetComponent<Attack>().Skill123){
            ChangeHPbarAmount(HP);
        }
        if(transform.localScale.y < 0.6f){
            Debug.Log("Squished!");
            Destroy(hpBar);
        }
        if(HP <= 0){
            Destroy(hpBar);
        }
        if(!Enemy){
            Destroy(hpBar);
        }
    }
    private void ChangeHPbarAmount(float amount){
        barImage1.fillAmount = amount * 0.01f * 2;

        if(barImage1.fillAmount > 0 && barImage1.fillAmount < 1){
            hpBar.SetActive(true);
        }
        else if(barImage1.fillAmount <= 0 || gameObject == null){
            Destroy(hpBar);
        }
    }
    public void DestroyHPBar(GameObject Enemy){
        if(!Enemy){
            destroyHPBar.isObjDestoryed = true;
            return;
        }
        Debug.Log("함수 실행됨!");
        destroyHPBar.isObjDestoryed = true;
    }
}
