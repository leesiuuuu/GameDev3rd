using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHPBar : MonoBehaviour
{
    private Image BarImage;
    public GameObject HPBAR;
    public bool isObjDestoryed = false;
    void Start()
    {
        BarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BarImage.fillAmount <= 0.02f){
            Destroy(HPBAR);
        }
        if(isObjDestoryed){
            Destroy(HPBAR);
        }
    }
}
