using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNextStageMove : MonoBehaviour
{
    public Transform PlayerMark;
    public GameObject Stage2;
    void Update()
    {
        if(GameManager.Instance.StageCount == 2){
            transform.position = PlayerMark.position;
            Stage2.SetActive(true);
            Destroy(PlayerMark.gameObject);
            GetComponent<PlayerNextStageMove>().enabled = false;
        }
    }
}
