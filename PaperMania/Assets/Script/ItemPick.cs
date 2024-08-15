using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPick : MonoBehaviour
{
    public float range = 0.8f;
    public GameObject FKey;
    public LayerMask PlayerLayer;
    private ItemInventoryUI IIU;
    void Start()
    {
        FKey.SetActive(false);
    }

    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, range, PlayerLayer);
        if(collider2Ds.Length == 0){
            FKey.SetActive(false);
        }
        else{
            FKey.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            foreach(Collider2D cols in collider2Ds){
                if(cols.gameObject.CompareTag("Player")){
                    if(GameManager.Instance.ItemList[0] == null || GameManager.Instance.ItemList[1] == null){
                        GameManager.Instance.ItemAdd(gameObject);
                        GameObject.Find("ItemBG").GetComponent<ItemInventoryUI>().InvenStart();
                        Destroy(gameObject);
                        break;                        
                    }
                else{
                    Debug.Log("현재 인벤토리가 꽉 찼습니다!");
                    break;
                }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
