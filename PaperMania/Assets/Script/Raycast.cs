using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public bool Come;
    public float maxDistence = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector3.down * maxDistence);
        if(hit2D.collider != null){
            if(hit2D.collider.gameObject.CompareTag("Player")){
                Come = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.down * maxDistence);
    }
}
