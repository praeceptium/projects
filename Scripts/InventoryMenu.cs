using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public GameObject inventoryMenu;
    public  bool isActive = false;
    public Button inventoryButton;
    public camera_movement cameraMove;

    public static InventoryMenu instance;
    void Awake()
    {
        instance = this;
    }

    public int space = 10;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public void OpenInventory()
    {
        if (isActive == false)
        {
            cameraMove.cameralock = true;
            inventoryMenu.SetActive(true);
            isActive = true;
            
        }
        else if (isActive == true)
        {
            cameraMove.cameralock = false;
            inventoryMenu.SetActive(false);
            isActive = false;
        }
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("There is no space in the bag.");
            return false;
        }
        items.Add(item);


        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
