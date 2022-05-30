using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mamaGeriKoy : MonoBehaviour
{
    public variables variable;
    public GameObject mama;
    public GameObject mama1;
    public GameObject mama2;
    public GameObject mama3;
    public GameObject mama4;
    public catfood mamascript;
    public catfood mamascript1;
    public catfood mamascript2;
    public catfood mamascript3;
    public catfood mamascript4;
    public GameObject mamatutus;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (variable.isHoldingFood == true)
        {
            
            if (mamascript.isEnabled == false)
            {
                mamascript.isEnabled = true;
                mama.SetActive(true);
                variable.isHoldingFood = false;
                mamatutus.SetActive(false);
            }
            else if (mamascript1.isEnabled == false)
            {
                mamascript1.isEnabled = true;
                mama1.SetActive(true);
                variable.isHoldingFood = false;
                mamatutus.SetActive(false);
            }
            else if (mamascript2.isEnabled == false)
            {
                mamascript2.isEnabled = true;
                mama2.SetActive(true);
                variable.isHoldingFood = false;
                mamatutus.SetActive(false);
            }
            else if (mamascript3.isEnabled == false)
            {
                mamascript3.isEnabled = true;
                mama3.SetActive(true);
                variable.isHoldingFood = false;
                mamatutus.SetActive(false);
            }
            else if (mamascript4.isEnabled == false)
            {
                mamascript4.isEnabled = true;
                mama4.SetActive(true);
                variable.isHoldingFood = false;
                mamatutus.SetActive(false);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
