using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControll : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform firstTarget;
    [SerializeField] private Transform secondTarget;
    [SerializeField] private Transform thirdTarget;
    [SerializeField] private Transform fourthTarget;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform rotationTransform;

    [SerializeField]  AudioSource jumpSound;

    Vector3 velocity;
    Vector3 startPositon;

    bool isIdle;
    bool firstMove=true;
    bool secondMove;
    bool thirdMove;
    bool fourthMove;
    //nullable bool needed for rotating platforms
    bool? onRight;
    public GameData data;
    // Start is called before the first frame update
    void Start()
    {
        isIdle = true;
        startPositon = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (data.gameStarted == true && data.paintPhase==false)
        {
            FirstTargetMove(firstMove);
            SecondTargetMove(secondMove);
            ThirdTargetMove(thirdMove);
            FourthTargetMove(fourthMove);

            if (isIdle == false)
            {
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }
            if (transform.position.y < -5)
            {
                transform.position = startPositon;
                firstMove = true;
                secondMove = false;
                thirdMove = false;
                fourthMove = false;
            }
        }
        if (gameObject.transform.position.z>38)
        {
            gameObject.SetActive(false);
        }
        
    }

    void FirstTargetMove(bool a)
    {
        if (a == true)
        {
            float step = speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, firstTarget.position) > 0.1f)
            {
                isIdle = false;
                transform.position = Vector3.MoveTowards(transform.position, firstTarget.transform.position, step);
                Debug.Log("moving to first target");
            }
            else
            {
                firstMove = false;
                secondMove = true;
            }
        }
        
    }

    void SecondTargetMove(bool a)
    {
        if(a == true)
        {
            float step = speed * Time.deltaTime;
            if (onRight == true)
            {
                isIdle = false;
                transform.position = Vector3.MoveTowards(transform.position, secondTarget.transform.position, step);
                Vector3 lookFRight = new Vector3(-1, 0, 1);
                Quaternion toRotation = Quaternion.LookRotation(lookFRight, Vector3.up);
                rotationTransform.transform.localRotation = Quaternion.RotateTowards(rotationTransform.transform.localRotation, toRotation, rotationSpeed * Time.deltaTime);
                Debug.Log("moving to second target right");
            }
            else
            {
                isIdle = false;
                transform.position = Vector3.MoveTowards(transform.position, secondTarget.transform.position, step);
                Vector3 lookFLeft = new Vector3(1, 0, 1);
                Quaternion toRotation = Quaternion.LookRotation(lookFLeft, Vector3.up);
                rotationTransform.transform.localRotation = Quaternion.RotateTowards(rotationTransform.transform.localRotation, toRotation, rotationSpeed * Time.deltaTime);
                Debug.Log("moving to second target left");
            }
            if(Vector3.Distance(transform.position, secondTarget.position) < 0.1f)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                rotationTransform.transform.localRotation = toRotation;
                secondMove = false;
                playerBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                jumpSound.Play();
                onRight = null;
                thirdMove = true;
                
            }
        }
    }
    void ThirdTargetMove(bool a)
    {
        if(a == true)
        {
            float step = speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, thirdTarget.position) > 0.1f)
            {
                isIdle = false;
                transform.position = Vector3.MoveTowards(transform.position, thirdTarget.transform.position, step);
                Debug.Log("moving to third target");
            }
            else
            {
                playerBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                jumpSound.Play();
                thirdMove = false;
                fourthMove = true;
            }
        }
    }
    void FourthTargetMove(bool a)
    {
        if (a == true)
        {
            float step = speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, fourthTarget.position) > 0.1f)
            {
                isIdle = false;
                transform.position = Vector3.MoveTowards(transform.position, fourthTarget.transform.position, step);
                Debug.Log("moving to fourth target");
            }
            else
            {
                thirdMove = false;
                fourthMove = true;
            }
        }
    }
    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the obstacle.
        float force = 3;

        // If the object we hit is the enemy
        if (c.gameObject.tag == "rotator")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            dir = new Vector3(dir.x, 0f, dir.z);
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            playerBody.velocity = Vector3.zero;
            playerBody.AddForce(dir * force, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "rotator")
        {
            playerBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpSound.Play();
        }
        if(other.tag == "rotatingPlatform")
        {
            speed = 0.75f;
            if (other.gameObject.GetComponent<RotatingPlatform>().rotateRight == true)
            {
                onRight = true;
            }
            else if(other.gameObject.GetComponent<RotatingPlatform>().rotateRight == false)
            {
                onRight = false;
            }
        }
        else
        {
            onRight = null;
            //don't forget to change in case of overall speed change from the inspector
            speed = 1f;
        }
    }
}
