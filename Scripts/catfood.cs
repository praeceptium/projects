using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catfood : MonoBehaviour
{
    public GameObject mamatutus;
    public GameObject mama;
    public variables variable;
    public bool isEnabled=false;
    int foodAmount = 2000;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    void OnMouseDown()
    {
        Debug.Log("mamaya bast�n");
        if (variable.isHoldingFood == false)
        {
            mamatutus.SetActive(true);
            mama.SetActive(false);
            variable.isHoldingFood = true;
            variable.holdingFoodAmount = foodAmount;
            isEnabled = false;
        }
       

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
