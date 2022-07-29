using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        item.healt = 20;

    }
    private void Update()
    {

    }

    public void OnMouseDown()
    {

        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = FindObjectOfType<InventoryMenu>().Add(item);

        if (wasPickedUp)
        {
            gameObject.SetActive(false);
            item.healt = 20;
        }



    }
}
