using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Slider loveSlider;
    public Slider dirtSlider;
    public Slider levelSlider;

    public Gradient hungerGradient;
    public Gradient thirstGradient;
    public Gradient loveGradient;
    public Gradient dirtGradient;
    public Gradient levelGradient;

    public Image hungerFill;
    public Image thirstFill;
    public Image loveFill;
    public Image dirtFill;
    public Image levelFill;

    public Image loveBack;
    public Image thirstBack;
    public Image hungerBack;
    public Image dirtBack;

    public Text percentageTexthunger;
    public Text percentageTextthirst;
    public Text percentageTextlove;
    public Text percentageTextdirt;

    public void SetHunger(int a)
    {
        
        hungerSlider.value = a;
        if (hungerSlider.value <= 150)
        {
            hungerBack.color = Color.red;
        }
        if (hungerSlider.value > 150)
        {
            hungerBack.color = Color.white;
        }

        hungerFill.color = hungerGradient.Evaluate(hungerSlider.normalizedValue);
    }
    
   public void SetThirst(int b)
    {
        thirstSlider.value = b;
        if (thirstSlider.value <= 100)
        {
            thirstBack.color = Color.red;
        }
        if (thirstSlider.value > 100)
        {
            thirstBack.color = Color.white;
        }


        thirstFill.color = thirstGradient.Evaluate(thirstSlider.normalizedValue);
    }

    public void SetLove(int c)
    {
        loveSlider.value = c;

        if (loveSlider.value <= 80)
        {
            loveBack.color = Color.red;
        }
        if (loveSlider.value > 80)
        {
            loveBack.color = Color.white;
        }


        loveFill.color = loveGradient.Evaluate(loveSlider.normalizedValue);
    }
    public void SetDirt(int d)
    {
        dirtSlider.value = d;
        
        if (dirtSlider.value <= 600)
        {
            dirtBack.color = Color.red;
        }
        if (dirtSlider.value > 600)
        {
            dirtBack.color = Color.white;
        }

        dirtFill.color = dirtGradient.Evaluate(dirtSlider.normalizedValue);
    }

    public void SetLevel(int e)
    {
        levelSlider.value = e;

        

        levelFill.color = levelGradient.Evaluate(levelSlider.normalizedValue);
    }

    public void TextUpdateHunger(float hunger)
    {
        percentageTexthunger.text = Mathf.RoundToInt(hunger / 6) + "%";
    }

    public void TextUptadeThirst (float thirst)
    {
        percentageTextthirst.text = Mathf.RoundToInt(thirst / 3) + "%";
    }

    public void TextUpdateLove (float love)
    {
        percentageTextlove.text = Mathf.RoundToInt(love / 3) + "%";
    }

    public void TextUptadeDirt (float dirt)
    {
        percentageTextdirt.text = Mathf.RoundToInt(dirt / 18) + "%";
    }

    
}
