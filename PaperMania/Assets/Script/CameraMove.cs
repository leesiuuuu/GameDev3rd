using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float LineSize = 10;
    public bool CameraMoveto = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * LineSize, Color.yellow);

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.forward, LineSize);
        if(hit2D.collider.gameObject.CompareTag("Player")){
            CameraMoveto = true;
        }
    }
}
