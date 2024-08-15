using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryUI : MonoBehaviour
{
    public Image Item1;
    public Image Item2;

    void Start()
    {

    }
    void Update(){
        if(GameManager.Instance.ItemList[0] == null){
            Item1.sprite = null;
        }
        if(GameManager.Instance.ItemList[1] == null){
            Item2.sprite = null;
        }
    }
    public void InvenStart(){
        List<GameObject> itemList = GameManager.Instance.ItemList;


        if(itemList.Count > 0 && itemList[0] != null)
        {
            Item1.sprite = itemList[0].GetComponent<SpriteRenderer>().sprite;
        }

        if(itemList.Count > 1 && itemList[1] != null)
        {
            Item2.sprite = itemList[1].GetComponent<SpriteRenderer>().sprite;
        }
        if(Item1.sprite == GameManager.Instance.PaperShield.GetComponent<SpriteRenderer>().sprite)
        {
            RectTransform RT = Item1.GetComponent<RectTransform>();
            RT.sizeDelta = new Vector2(50, 100);
        }
        if(Item1.sprite == GameManager.Instance.HotPack.GetComponent<SpriteRenderer>().sprite)
        {
            RectTransform RT = Item1.GetComponent<RectTransform>();
            RT.sizeDelta = new Vector2(60, 100);
        }
    }
}
