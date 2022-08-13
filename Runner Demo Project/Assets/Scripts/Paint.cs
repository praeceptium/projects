using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paint : MonoBehaviour
{
    [SerializeField] float paintedCubes;
    float a = 25.6f;
    float percentage;
    float speed = 3f;
    public GameData data;
    Vector3 playerMovementInput;
    [SerializeField] Rigidbody playerBody;
    [SerializeField] TextMeshProUGUI percentageText;
    [SerializeField] GameObject percentageTextActive;
    [SerializeField] GameObject restartText;

    // Start is called before the first frame update
    void Start()
    {
        data.paintPhase = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < 11.5f && data.paintPhase == true)
        {
            playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            playerBody.velocity = new Vector3(playerMovementInput.x * speed,1f,0f);
            PercentageCalcute();
        }
        if (transform.position.y > 11.5f)
        {
            playerBody.velocity = Vector3.zero;
            restartText.SetActive(true);
        }
        if (transform.position.x > 1.238f)
        {
            transform.position = new Vector3 (1.237f,transform.position.y,transform.position.z);
        }
        if (transform.position.x < -0.5f)
        {
            transform.position = new Vector3(-0.499f, transform.position.y, transform.position.z);
        }
    }
 
    void PercentageCalcute()
    {
        percentage = paintedCubes / a;
        percentageText.text = ("%" + (int)percentage);
        percentageTextActive.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "paintableCube")
        {
            if (other.GetComponent<Renderer>().material.color != Color.red)
            {
                paintedCubes += 1;
            }
            other.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("changedcolor");
        }
        
    }
}
