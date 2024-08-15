using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject Prefab;
    public int Paper;

    public void DropItems()
    {
        for (int i = 0; i < Paper; i++)
        {
            GameObject clone = Instantiate(Prefab, transform.position, Quaternion.identity);
        }
    }
}