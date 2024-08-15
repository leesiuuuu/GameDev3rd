using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float Speed = 5.0f;
    private GameObject player;
    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * Speed * Time.deltaTime, dir.y * Speed * Time.deltaTime + 0.03f, 0.0f);
        this.transform.Translate(moveVector);
    }
}
