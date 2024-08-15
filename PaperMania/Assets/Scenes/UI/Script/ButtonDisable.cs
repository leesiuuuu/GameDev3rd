using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour
{
    private Button button;
    
    void Start(){
        button = GetComponent<Button>();
        OnButtonDisable();
        Invoke("OnButtonEnable", 1.5f);
    }

    void OnButtonDisable(){
        button.interactable = false;
    }
    void OnButtonEnable(){
        button.interactable = true;
    }
}
