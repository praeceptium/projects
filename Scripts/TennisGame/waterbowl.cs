using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterbowl : MonoBehaviour
{
    public Cat cat;
    bool isBowlFull;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (cat.catThirst < 300)
        {
            cat.catThirst += (10 * Time.deltaTime);
        }
        Debug.Log("sukabi");


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
