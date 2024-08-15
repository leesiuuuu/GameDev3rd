using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BombThrow : MonoBehaviour
{
    public GameObject Prefab;
    private Transform player;
    public float throwForce = 10f;
    public float Range;
    public float AtkCool;
    private bool isAttack = false;
    private bool OnePrefab = false;
    private Animator animator;
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(!isAttack){
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Range);
            foreach(Collider2D cols in colliders){
                if (cols.gameObject.CompareTag("Player"))
                {
                    Vector3 direction = cols.transform.position - transform.position;
                    direction.Normalize();
                    if (direction.x > 0)
                    {
                        transform.localScale = new Vector3(-1.18f, transform.localScale.y, 1.18f);
                        animator.SetBool("ThrowReady", true);
                        StartCoroutine(ThrowBomb(0.5f));
                        break;
                    }
                    if (direction.x < 0)
                    {
                        transform.localScale = new Vector3(1.18f, transform.localScale.y, 1.18f);
                        animator.SetBool("ThrowReady", true);
                        StartCoroutine(ThrowBomb(0.5f));
                        break;
                    }
                }
            }
        }
    }
    private IEnumerator ThrowBomb(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("Throw", true);
        isAttack = true;
        if(!OnePrefab){
            GameObject Bomb = Instantiate(Prefab, transform.position, Quaternion.identity);
            OnePrefab = true;
        }
        animator.SetBool("ThrowReady", false);
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("Throw", false);
        yield return new WaitForSeconds(AtkCool);
        isAttack = false;
        OnePrefab = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
