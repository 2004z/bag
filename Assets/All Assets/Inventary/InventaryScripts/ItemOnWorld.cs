using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventary playerInventary;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()
    {
        if (!playerInventary.itemList.Contains(thisItem))
        {
            //playerInventary.itemList.Add(thisItem);
            //InventaryManager.CreatNewItem(thisItem);
            for(int i = 0; i < playerInventary.itemList.Count; i++)
            {
                if (playerInventary.itemList[i] == null)
                {
                    playerInventary.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventaryManager.RefreshItem();
    }
}
