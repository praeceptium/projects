using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayCycle : MonoBehaviour
{
    [Range(0, 3600)] public float aDay;
    public int dayCount;
    public variables var;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aDay += (1 * Time.deltaTime);

        if (aDay >= 3600)
        {
            dayCount += 1;
            aDay = 0;
            var.catmoney += 500;
            Debug.Log("deneme");
        }
    }
}
