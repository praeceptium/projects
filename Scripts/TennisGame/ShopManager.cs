using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public variables variable;
    public GameObject mama;
    public GameObject mama1;
    public GameObject mama2;
    public GameObject mama3;
    public GameObject mama4;
    public GameObject brush;
    public GameObject toyBall;
    public GameObject shampoo;
    public GameObject textBrush;
    public GameObject textBall;
    public GameObject textShampoo;
    public catfood mamascript;
    public catfood mamascript1;
    public catfood mamascript2;
    public catfood mamascript3;
    public catfood mamascript4;
    // Start is called before the first frame update
    public void BuyFood()
    {
        if (variable.catmoney >= 50)
        {
            variable.catmoney = variable.catmoney - 50;
            variable.catfood = variable.catfood + 1;
            if (mamascript.isEnabled == false)
            {
                mamascript.isEnabled = true;
                mama.SetActive(true);
            }
            else if (mamascript1.isEnabled == false)
            {
                mamascript1.isEnabled = true;
                mama1.SetActive(true);
            }
            else if (mamascript2.isEnabled == false)
            {
                mamascript2.isEnabled = true;
                mama2.SetActive(true);
            }
            else if (mamascript3.isEnabled == false)
            {
                mamascript3.isEnabled = true;
                mama3.SetActive(true);
            }
            else if (mamascript4.isEnabled == false)
            {
                mamascript4.isEnabled = true;
                mama4.SetActive(true);
            }

        }
    }

    public void BuyShampoo()
    {
        if (variable.catmoney >= 80)
        {
            variable.catmoney = variable.catmoney - 80;
            variable.shampoo = variable.shampoo + 1;
            shampoo.SetActive(true);
            // textShampoo.SetActive(false);
        }
    }

    public void BuyBrush()
    {
        if (variable.catmoney >= 50)
        {
            variable.catmoney = variable.catmoney - 50;
            variable.brush = variable.brush + 1;
            brush.SetActive(true);
            textBrush.SetActive(false);


        }
    }

    public void BuyToyBall()
    {
        if (variable.catmoney >= 50)
        {
            variable.catmoney = variable.catmoney - 50;
            variable.toyBall = variable.toyBall + 1;
            toyBall.SetActive(true);

            textBall.SetActive(false);


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
