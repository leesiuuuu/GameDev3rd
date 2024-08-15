using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightSetting : MonoBehaviour
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
        isPinned = camera.GetComponent<CameraPin>().isPinned;
        isEnd = camera.GetComponent<CameraPin>().isEnd;
        if(isPinned){
            Debug.Log("작동됨!");
            DOTween.To(() => light.intensity, x => light.intensity = x, 400, 0.8f);
            camera.GetComponent<CameraPin>().isPinned = false;
        }
        else if(isEnd){
            DOTween.To(() => light.intensity, x => light.intensity = x, 300.69f, 0.8f).SetDelay(0.7f);
            camera.GetComponent<CameraPin>().isEnd = false;
        }

    }
}
