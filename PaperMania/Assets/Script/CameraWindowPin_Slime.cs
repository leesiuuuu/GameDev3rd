using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraWindowPin_Slime : MonoBehaviour
{
    private GameObject Camera;
    private Camera camera1;
    private GameObject Ray;
    void Start()
    {
        Ray = GameObject.Find("Ray");
        Camera = GameObject.Find("Main Camera");
        camera1 = Camera.GetComponent<Camera>();
    }

    void Update()
    {
        if(Ray.GetComponent<Raycast>().Come){
            Vector3 worldPos = camera1.WorldToViewportPoint(transform.position);
            if(worldPos.x < 0f) worldPos.x = 0f;
            if(worldPos.y < 0f) worldPos.y = 0f;
            if(worldPos.x > 1f) worldPos.x = 1f;
            if(worldPos.y > 1f) worldPos.y = 1f;
            transform.position = camera1.ViewportToWorldPoint(worldPos);
        }
    }
}
