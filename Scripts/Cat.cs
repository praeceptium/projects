using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [Range(0, 600)] public float catHunger;
    [Range(0, 300)] public float catThirst;
    [Range(0, 300)] public float catLove;
    [Range(0, 1800)] public float catDirt;


    public int hungerDecay = 1;
    public Transform target;
    public float smoothSpeed = 0.000125f;
    public Vector3 offset;
    public GameObject GO;
    public Transform cameraBack;
    public camera_movement camlock;
    public float moveSpeed;
    public bool movementLock=false;
    public bool isHungry = false;
    public bool isThirsty = false;
    public bool isCatZoomed = false;
    public bool isInLivingRoom;
    public bool isInKitchen;
    public bool isInBathRoom;
    public bool isInBedRoom;
    public Transform restingPosition;
    
    public BarControl barControlScript;
    public variables variables;



    public GameObject hungerBar;
    public GameObject thirstBar;
    public GameObject loveBar;
    public GameObject dirtBar;




    void OnMouseDown()
    {
        if (variables.isHoldingFood == false)
        {
            Debug.Log("click");
            Vector3 desiredPosition = target.position + offset;
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            Camera.main.transform.position = desiredPosition;

            GO.SetActive(true);
            camlock.cameralock = true;
            isCatZoomed = true;
            // bar komutlarini aktif eder kediye tiklandiginda
            hungerBar.SetActive(true);
            thirstBar.SetActive(true);
            loveBar.SetActive(true);
            dirtBar.SetActive(true);
        }
    }

    
    //back butonu kapatma + eski kamera pozisyonu
    public void back()
    {
        GO.SetActive(false);
        Vector3 desiredPosition = cameraBack.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1);
        Camera.main.transform.position = smoothedPosition;
        camlock.cameralock = false;
        isCatZoomed = false;
        // bar komutlari deaktif eder
        hungerBar.SetActive(false);
        thirstBar.SetActive(false);
        loveBar.SetActive(false);
        dirtBar.SetActive(false);

    }
    

    // Update is called once per frame
    void Update()
    {
        if (catHunger >= 0)
        {
            catHunger -= (hungerDecay * Time.deltaTime);
        }
        
        barControlScript.SetHunger((int)catHunger); // acligi bar olarak gosterir
        if (catThirst >= 0)
        {
            catThirst -= (2 * Time.deltaTime);
        }
        
        barControlScript.SetThirst((int)catThirst);
        if (catLove >= 0)
        {
            catLove -= (2 * Time.deltaTime);
        }
        
        barControlScript.SetLove((int)catLove);
        if (catDirt >= 0)
        {
            catDirt -= Time.deltaTime;
        }
        
        barControlScript.SetDirt((int)catDirt);

        if (catHunger < 300)
        {

            isHungry = true;
        }   
        if (catHunger > 550)
        {
            isHungry = false;
        }
        if (catThirst < 150)
        {

            isThirsty = true;
        }
        
        if (catThirst > 270)
        {
                
            isThirsty = false;
        }
       

        //kamera uçma olayý
      
    }
}

