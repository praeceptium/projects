using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popupHunger;
    //public GameObject popupThirst;
    public Cat cat;

    // Start is called before the first frame update
    void Start()
    {
        popupHunger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowPopup();
    }

    public void ShowPopup()
    {
        if (cat.catHunger < 450)
        {
            popupHunger.SetActive(true);



        }
    }

}
