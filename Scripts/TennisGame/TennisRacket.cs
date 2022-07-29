using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisRacket : MonoBehaviour
{
    private Touch touch;
    private float SpeedModifier;
    public Rigidbody t_Rigidbody = new Rigidbody();
    [SerializeField] GameObject ball = new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        SpeedModifier = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch=Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved){
                transform.position = new Vector3(
                transform.position.x + -touch.deltaPosition.y * SpeedModifier * Time.deltaTime,
                transform.position.y,
                transform.position.z + touch.deltaPosition.x * SpeedModifier * Time.deltaTime);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            if (transform.position.z < ball.transform.position.z)
            {
                Debug.Log("sol");
                if(ball.transform.position.z - transform.position.z <= 0.0020f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(ball.transform.right * 20);
                    Debug.Log("0.002");
                }
                if (ball.transform.position.z - transform.position.z <= 0.0040f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(ball.transform.right * 40);
                    Debug.Log("0.004");
                }
                if (ball.transform.position.z - transform.position.z <= 0.0060f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(ball.transform.right * 60);
                    Debug.Log("0.006");
                }
                if (ball.transform.position.z - transform.position.z <= 0.0080f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(ball.transform.right * 80);
                    Debug.Log("0.008");
                }
                
            }
            if (transform.position.z > ball.transform.position.z)
            {
                Debug.Log("sað");
                if (transform.position.z - ball.transform.position.z <= 0.0020f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(-ball.transform.right * 20);
                    Debug.Log("0.002");
                }
                if (transform.position.z - ball.transform.position.z <= 0.0040f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(-ball.transform.right * 40);
                    Debug.Log("0.004");
                }
                if (transform.position.z - ball.transform.position.z <= 0.0060f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(-ball.transform.right * 60);
                    Debug.Log("0.006");
                }
                if (transform.position.z - ball.transform.position.z <= 0.0080f)
                {
                    t_Rigidbody.AddForce(ball.transform.forward * 150);
                    t_Rigidbody.AddForce(-ball.transform.right * 80);
                    Debug.Log("0.008");
                }
            }
        }
    }

}
