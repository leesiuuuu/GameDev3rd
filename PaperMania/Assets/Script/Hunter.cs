using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public float HP = 40;
    public GameObject DeathEffect;
    public Transform HunterPos;
    private ItemDrop itemDrop;
    private bool isDead = false;
    private HPBar1 hPBar1;
    void Start(){
        itemDrop = GetComponent<ItemDrop>();
        hPBar1 = GetComponent<HPBar1>();
        hPBar1.Hunter = gameObject;
    }

    void Update()
    {
        if(HP <= 0 && !isDead){
            itemDrop.DropItems();
            isDead = true;
            Death();
        }
    }
    void Death(){
        GameObject clone = Instantiate(DeathEffect);
        clone.transform.position = new Vector3(HunterPos.position.x, HunterPos.position.y, 19);
        hPBar1.DestroyHPBar(gameObject);
        Destroy(this.gameObject);
        Destroy(clone, 0.2f);
    }
}
