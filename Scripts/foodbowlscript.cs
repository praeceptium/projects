using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodbowlscript : MonoBehaviour
{
    public Cat cat;
    public float bowlFood=0;
    public float bowlFoodMax = 4000;
    public variables variable;
    public GameObject mamatutus;
    float toyChance;

    public ItemPickup itemPickup1;
    public ItemPickup itemPickup2;
    // Start is called before the first frame update
    void OnTriggerStay (Collider other)
    {
        if (cat.catHunger < 600 && bowlFood>=10)
        {
            cat.catHunger += (10 * Time.deltaTime);
            bowlFood = bowlFood-(10 * Time.deltaTime);
        }
        Debug.Log("yemekkabi");
 

    }

    void OnMouseDown()
    {
        if (variable.isHoldingFood == true && variable.holdingFoodAmount<=bowlFoodMax-bowlFood)
        {
            addFood(variable.holdingFoodAmount);
            variable.holdingFoodAmount = 0;
            mamatutus.SetActive(false);
            variable.isHoldingFood = false;
            variable.catfood -= 1;
            toyChance = Random.Range(0f, 10f);
            if (toyChance <= 10)
            {
                Debug.Log("oyuncak kazandýn");
                //oyuncaðý aktif edip envantere eklenecek script buraya gelecek
                if (toyChance <= 5)
                {

                    itemPickup1.OnMouseDown();
                }
                if (toyChance > 5)
                {

                    itemPickup2.OnMouseDown();
                }
            }
        }
    }

    public void addFood(int mama)
    {
        bowlFood += mama;
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
