using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC1 : MonoBehaviour
{
    public bool isVisible = false;
    private GameObject TB1;
    private GameObject Alarm;
    public GameObject Player;
    private GameObject Camera;
    private bool end = false;
    public float Range;
    void Start(){
        Camera = GameObject.Find("Main Camera");
        isVisible = false;
        Alarm = GameObject.Find("Alarm");
        TB1 = GameObject.Find("TalkBalloon");
        TB1.SetActive(false);
        TB1.GetComponent<TalkBalloon>().enabled = false;
        Alarm.SetActive(false);
    }
    void Update(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach(Collider2D cols in colliders){
            if(cols.gameObject.CompareTag("Player") && !end){
                Player.GetComponent<PlayerMovement>().enabled = false;
                Player.GetComponent<AttackKey>().enabled = false;
                Player.GetComponent<Animator>().SetBool("Walking", false);
                Camera.GetComponent<CameraToObject>().enabled = true;
                Camera.GetComponent<SmoothCameraFollow>().enabled = false;
                Camera.GetComponent<CameraToObject>().isStart = true;
                Invoke("TB", 0.3f);
            }
        }
    }
    private void OnBecameVisible(){
        isVisible = true;
        Alarm.SetActive(true);
    }
    private void OnBecameInvisible(){
        isVisible = false;
        Alarm.SetActive(false);
    }
    void TB(){
        TB1.SetActive(true);
        TB1.GetComponent<TalkBalloon>().enabled = true;
        end = true;
        Alarm.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
