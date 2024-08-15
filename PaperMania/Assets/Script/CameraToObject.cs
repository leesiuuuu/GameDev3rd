using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraToObject : MonoBehaviour
{
    public GameObject Camera;
    private GameObject NPC;
    public bool isStart = false;
    void Start()
    {
        NPC = GameObject.Find("NPC1");
        GetComponent<CameraToObject>().enabled = false;
    }
    void Update(){
        if(isStart){
            Camera camera = Camera.GetComponent<Camera>();
            camera.transform.DOMove(new Vector3(NPC.transform.position.x, NPC.transform.position.y+1.5f, 7.9f), 1f, false).SetEase(Ease.OutSine);
            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, 4f, 1f).SetEase(Ease.OutSine);
            isStart = false;
        }
    }

    // Update is called once per frame
    public void CameraReturn(){
        Camera camera = Camera.GetComponent<Camera>();
        DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, 5.5f, 1f).SetEase(Ease.OutSine);
        GetComponent<CameraToObject>().enabled = false;
        GetComponent<SmoothCameraFollow>().enabled = true;
    }
}
