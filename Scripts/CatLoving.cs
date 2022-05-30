using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLoving : MonoBehaviour
{
    public Cat cat;
    private void OnEnable()
    {
        // Subcribe to events when object is enabled
        TouchManager.OnTouchDrag += OnTouchDrag;
    }

    private void OnDisable()
    {
        // Unsubcribe from events when object is disabled
        TouchManager.OnTouchDrag -= OnTouchDrag;
    }
    private void OnTouchDrag(Touch eventData)
    {
        if (cat.catLove <= 300 && cat.isCatZoomed == true)
        {
            cat.catLove += 0.2f;
        }
    }
}
