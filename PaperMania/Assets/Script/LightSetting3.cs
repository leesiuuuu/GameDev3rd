using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightSetting3 : MonoBehaviour
{
    public new GameObject camera;
    private new Light light;
    private bool isPinned;
    private bool isEnd;
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        isPinned = camera.GetComponent<CameraPin_Stage3>().isPinned;
        isEnd = camera.GetComponent<CameraPin_Stage3>().isEnd;
        if(isPinned){
            Debug.Log("작동됨!");
            DOTween.To(() => light.intensity, x => light.intensity = x, 440, 0.8f);
            camera.GetComponent<CameraPin_Stage3>().isPinned = false;
        }
        else if(isEnd){
            DOTween.To(() => light.intensity, x => light.intensity = x, 300.69f, 0.8f).SetDelay(0.7f);
            camera.GetComponent<CameraPin_Stage3>().isEnd = false;
        }

    }
}
