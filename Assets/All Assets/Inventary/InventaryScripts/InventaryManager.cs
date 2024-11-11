using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaryManager : MonoBehaviour
{
    static InventaryManager instance;

    public Inventary mybag;
    public GameObject slotGeid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }
    //item的信息传输给slot再传输给item
    /*public static void CreatNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGeid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGeid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/
    public static void RefreshItem()
    {
        for(int i = 0; i < instance.slotGeid.transform.childCount; i++)
        {
            if (instance.slotGeid.transform.childCount == 0)
                break;
            Destroy(instance.slotGeid.transform.GetChild(i).gameObject);
            
        }
        instance.slots.Clear();
        for (int i = 0; i < instance.mybag.itemList.Count; i++)
        {
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGeid.transform);
            instance.slots[i].transform.localScale =new Vector3(1, 1, 1);
            instance.slots[i].GetComponent<Slot>().SetUpSlot(instance.mybag.itemList[i]);
        }
    }
}
