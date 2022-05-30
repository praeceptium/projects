using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public int healt = 20;




    // public bool IsDefaultItem = false;

    public virtual void Use()
    {
        //use item 
        // something might happen

        Debug.Log("Using " + name);
        if (name == "Brush")
        {
            healt -= 10;
        }
        if (name == "Toy Ball")
        {
            healt -= 10;
        }
        if (name == "Shampoo")
        {
            healt -= 10;
        }
    }
}
