using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraPause : MonoBehaviour
{
    public Camera camera;
    public Transform Pin;
    private bool Once = false;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isEnd && GameManager.Instance.isStageClear){
            GetComponent<SmoothCameraFollow>().enabled = false;
            Once = true;
        }
        if(Once){
            camera.transform.DOMove(Pin.position, 0.8f, false);
            Once = false;
        }
    }
}
