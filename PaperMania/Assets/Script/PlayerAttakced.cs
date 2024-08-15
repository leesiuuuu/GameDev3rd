using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerAttakced : MonoBehaviour
{
    public bool isAtked = false;
    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.localScale.x > 0 ? Vector3.left : Vector3.right) * 0.2f;
        if(isAtked){
            GetComponent<PlayerMovement>().BombAtked = true;
            isAtked = false;
        }
    }
}
