using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAutomove : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.DOMoveX(transform.position.x + 40f, 5f, false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walking", true);
    }
}
