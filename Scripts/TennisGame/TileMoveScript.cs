using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMoveScript : MonoBehaviour
{

    public GameObject cat;
    public GameObject tile;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject tile10;
    public GameObject tile11;
    public GameObject tile12;
    public GameObject tile13;
    public GameObject tile14;
    public GameObject tile15;

    public float moveSpeed;
    public bool isTouched;
    public Vector3 offset;
    public Vector3 offset2;
    public bool isMoving;
    public Cat catscript;
    public Animator animationController;
    public InventoryMenu inventoryMenu;
    private void Start()
    {
        catscript.isInLivingRoom = true;
    }
    private void OnEnable()
    {
        // Subcribe to events when object is enabled
        
        TouchManager.OnTouchUp += OnTouchUp;
        
    }

    private void OnDisable()
    {
        // Unsubcribe from events when object is disabled
        
        TouchManager.OnTouchUp -= OnTouchUp;
        
    }
    private void OnMouseDown()
    {
        Debug.Log("1");
        isTouched = true;
    }
    public void OnTouchUp(Touch eventData)
    {
        
        
        if (isTouched == true && catscript.isInLivingRoom==true)
        {
            
            isTouched = false;
            Debug.Log(tile.transform.position+offset);
            isMoving = true;
            tile1.SetActive(false);
            tile2.SetActive(false);
            tile3.SetActive(false);
            tile4.SetActive(false);
            tile5.SetActive(false);
            tile6.SetActive(false);
            tile7.SetActive(false);
            tile8.SetActive(false);
            tile9.SetActive(false);
            tile10.SetActive(false);
            tile11.SetActive(false);
            tile12.SetActive(false);
            tile13.SetActive(false);
            tile14.SetActive(false);
            tile15.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        if (catscript.isCatZoomed == false && inventoryMenu.isActive == false)
        {
            if (isMoving == true)
            {
                animationController.SetBool("trigger", true);
                Vector3 offSetposition = tile.transform.position + offset;
                cat.transform.position = Vector3.MoveTowards(cat.transform.position, tile.transform.position + offset, step);
                Vector3 targetDirection = ((tile.transform.position + offset2) - cat.transform.position).normalized;
                Quaternion targetRotation;
                targetRotation = Quaternion.LookRotation(targetDirection);
                cat.transform.rotation = Quaternion.Slerp(cat.transform.rotation, targetRotation, Time.deltaTime * 5);
                if (cat.transform.position.x == offSetposition.x && cat.transform.position.z == offSetposition.z)
                {
                    isMoving = false;
                    tile1.SetActive(true);
                    tile2.SetActive(true);
                    tile3.SetActive(true);
                    tile4.SetActive(true);
                    tile5.SetActive(true);
                    tile6.SetActive(true);
                    tile.SetActive(false);
                    tile7.SetActive(true);
                    tile8.SetActive(true);
                    tile9.SetActive(true);
                    tile10.SetActive(true);
                    tile11.SetActive(true);
                    tile12.SetActive(true);
                    tile13.SetActive(true);
                    tile14.SetActive(true);
                    tile15.SetActive(true);
                    animationController.SetBool("trigger", false);
                }
            }
        }
    }

}
