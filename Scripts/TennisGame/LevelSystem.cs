using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public Cat cat;
    public BarControl barControlScript;


    public float level;
    public float xp;
    float maxXp = 50;
    public Text levelText;

    public bool oneTime = false;
    public bool oneTimeThirst = false;
    public bool oneTimeLove = false;




    private void Start()
    {
        level = 0;
        xp = 0;
    }


    private void Update()
    {
        AddLevel();
        barControlScript.SetLevel((int)xp);


        levelText.text = level.ToString();




    }


    public void AddLevel()
    {
        if (cat.catHunger >= 550 && oneTime == false)
        {

            xp += 10f;
            oneTime = true;
        }

        if (cat.catThirst >= 270 && oneTimeThirst == false)
        {
            xp += 10f;
            oneTimeThirst = true;
        }

        if (cat.catLove >= 300 && oneTimeLove == false)
        {

            xp += 10f;
            oneTimeLove = true;

        }

        if (cat.catHunger < 550)
        {
            oneTime = false;
        }

        if (cat.catThirst < 270)
        {
            oneTimeThirst = false;
        }

        if (cat.catLove < 100)
        {
            oneTimeLove = false;
        }


        if (xp >= maxXp)
        {
            xp = 0;
            level += 1;
            maxXp = maxXp * 1.5f;

            barControlScript.levelFill.color = barControlScript.levelGradient.Evaluate(barControlScript.levelSlider.minValue);
            barControlScript.levelSlider.maxValue = maxXp;
            barControlScript.levelSlider.value = 0;
        }

    }


}
