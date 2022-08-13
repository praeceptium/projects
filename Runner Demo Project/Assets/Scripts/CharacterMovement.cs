using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 playerMovementInput;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private Transform feetTransform;
    [SerializeField] private Vector3 startTransform;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundmask;
    [SerializeField] private Rigidbody playerBody;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource jumpSound;

    Vector3 velocity;
    bool isGrounded;
    bool runFinished = false;
    public GameData data;
    private void Start()
    {
        startTransform = transform.position;
    }
    void FixedUpdate()
    {
        if (runFinished == false && data.gameStarted == true)
        {
            playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            MovePlayer();

            if (transform.position.y < -4)
            {
                transform.position = startTransform;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && data.gameStarted==true)
        {
            if (Physics.CheckSphere(feetTransform.position, groundDistance, groundmask))
            {
                playerBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                jumpSound.Play();
            }
        }
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(playerMovementInput) * speed;
        playerBody.velocity = new Vector3(MoveVector.x, playerBody.velocity.y, MoveVector.z);

        

        if(MoveVector != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }


    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the obstacle.
        float force = 60;

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
        if(other.tag == "FinishingPlace")
        {
            runFinished = true;
            animator.SetBool("IsRunning", false);
            data.paintPhase = true;
        }
    }
}
