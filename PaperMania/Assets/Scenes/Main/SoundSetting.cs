using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoundSetting : MonoBehaviour
{
    public AudioSource Main;
    public Slider slider;
    public RectTransform SoundBG;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Main.volume = slider.value;
    }
    public void SettingWindow(){
        SoundBG.DOAnchorPos(new Vector3(0,0,0), 0.7f)
        .SetEase(Ease.OutCirc)
        .SetUpdate(true);
    }
    public void ReturnWindow(){
        SoundBG.DOAnchorPos(new Vector3(0,1126,0), 0.7f)
        .SetEase(Ease.OutCirc)
        .SetUpdate(true);
    }
}
