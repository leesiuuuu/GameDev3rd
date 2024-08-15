using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerWindowPin : MonoBehaviour
{
    public GameObject Camera;
    private Camera camera1;
    public GameObject Player;
    void Start()
    {
        camera1 = Camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = camera1.WorldToViewportPoint(Player.transform.position);
        if(worldPos.x < 0f) worldPos.x = 0f;
        if(worldPos.y < 0f) worldPos.y = 0f;
        if(worldPos.x > 1f) worldPos.x = 1f;
        if(worldPos.y > 1f) worldPos.y = 1f;
        Player.transform.position = camera1.ViewportToWorldPoint(worldPos);
    }
}
