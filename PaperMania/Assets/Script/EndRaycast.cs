using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRaycast : MonoBehaviour
{
    public float maxDistence;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector3.down * maxDistence);
        if(hit2D.collider != null){
            if(hit2D.collider.gameObject.CompareTag("Player") && GameManager.Instance.isStageClear){
                GameManager.Instance.isEnd = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, Vector3.down * maxDistence);
    }
}
