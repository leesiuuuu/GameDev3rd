using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<AttackKey>().enabled = false;
        Invoke("ReturnScript", 1.3f);
    }
    void ReturnScript(){
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<AttackKey>().enabled = true;
    }


}
