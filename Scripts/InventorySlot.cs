using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public ShopManager shopManager;
    public Cat cat;


    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public virtual void ClearSlot()
    {

        item = null;

        icon.sprite = null;
        icon.enabled = false;

    }
    public void OnRemoveButton()
    {
        InventoryMenu.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            if (item.name == "Brush")
            {
                cat.catDirt -= 50;
            }
            if (item.name == "Toy Ball")
            {
                cat.catLove += 50;
            }
            if (item.name == "Shampoo")
            {
                cat.catDirt -= 50;
            }
            if (item.healt <= 0)
            {
                InventoryMenu.instance.Remove(item);
                shopManager.textBrush.SetActive(true);
                shopManager.textBall.SetActive(true);
                shopManager.textShampoo.SetActive(true);
            }



        }
    }
}
