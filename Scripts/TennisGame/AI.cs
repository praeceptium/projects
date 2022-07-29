using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] GameObject ball = new GameObject();
    public Rigidbody t_Rigidbody = new Rigidbody();
    [SerializeField] float ballForward = 275;
    [SerializeField] float ballUpward = 30;
    public GameHandler script;
    public Rigidbody ballRb;
    public float normalGameSpeed = 1f;
    public float hardcoreModeSpeed = 2f;

    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void hardcoreMode()
    {
        normalGameSpeed = hardcoreModeSpeed;
    }
    public void NormalMode()
    {
        normalGameSpeed = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 BallPosition;
        if (ball.transform.position.x < -1)
        {
            BallPosition = new Vector3(-1.318f, ball.transform.position.y, ball.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, BallPosition, normalGameSpeed * Time.deltaTime);
        }  
        else if(script.playerLastHit==true && script.aiBounce == 1 && ball.transform.position.x > -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, normalGameSpeed * Time.deltaTime);
        }
        else
        {
            BallPosition = new Vector3(-1.318f, 0.982f, ball.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, BallPosition, normalGameSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            if (script.aisFirstShot == true)
            {
                ballForward = 100;
            }
            else
            {
                ballForward = 170;
            }
            Debug.Log("aihit");
            script.aiLastHit = true;
            script.aiBounce = 0;
            script.playerBounce = 0;
            script.playerLastHit = false;
            ballRb.isKinematic = false;
            hitSound.Play();
            if (transform.position.z < 0)
            {
                if (transform.position.z >= -0.2)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(ball.transform.right * 20);
                }
                else if (transform.position.z >= -0.4 && transform.position.z < -0.2)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(ball.transform.right * 40);
                }
                else if (transform.position.z >= -0.6 && transform.position.z < -0.4)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(ball.transform.right * 60);
                }
                else if (transform.position.z >= -0.8 && transform.position.z < -0.6)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(ball.transform.right * 80);
                }
                else if (transform.position.z < -0.8)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(ball.transform.right * 100);
                }
            }
            else if (transform.position.z > 0)
            {
                Debug.Log("z buyuk");
                if (transform.position.z <= 0.2)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(-ball.transform.right * 20);
                }
                else if (transform.position.z <= 0.4 && transform.position.z > 0.2)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(-ball.transform.right * 40);
                }
                else if (transform.position.z <= 0.6 && transform.position.z > 0.4)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(-ball.transform.right * 60);
                }
                else if (transform.position.z <= 0.8 && transform.position.z > 0.6)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(-ball.transform.right * 80);
                }
                else if (transform.position.z > 0.8)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(-ball.transform.right * 100);
                }
            }
            else
            {
                Debug.Log("coord0");
                float rand = Random.Range(0f, 10f);
                if (rand < 5)
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(-ball.transform.right * 20);
                }
                else
                {
                    t_Rigidbody.velocity = new Vector3(0, 0, 0);
                    t_Rigidbody.AddForce(-ball.transform.forward * ballForward);
                    t_Rigidbody.AddForce(ball.transform.up * ballUpward);
                    t_Rigidbody.AddForce(ball.transform.right * 20);
                }
            }
        }
    }
}
