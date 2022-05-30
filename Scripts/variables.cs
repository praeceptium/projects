using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class variables : MonoBehaviour
{
    public int catmoney = 500;
    public int catfood = 0;
    public int catlitter = 0;
    public int shampoo = 0;
    public int brush = 0;
    public int toyBall = 0;
    public int holdingFoodAmount;
    public bool isHoldingFood;


    public TextMeshProUGUI catmoneyUI;
    public TextMeshProUGUI catfoodUI;
    // Start is called before the first frame update
    void Start()
    {
        isHoldingFood = false;

    }

    // Update is called once per frame
    void Update()
    {
        catmoneyUI.text = catmoney.ToString();
        catfoodUI.text = catfood.ToString();
    }
}
