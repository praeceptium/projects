using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTeleport : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameHandler script;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ballTeleport()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (script.playerServiceShot == true)
        {
            transform.position = new Vector3(1.19200003f, 1.12800002f, 0f);
        }
        else
        {
            transform.position = new Vector3(-1.28400004f, 1.12800002f, 0f);
        }
        rb.isKinematic = true;
        if (script.playerServiceShot == true){
            script.playersFirstShot = true;
            script.aisFirstShot = false;
            Debug.Log("playerfirstshotsettrue");
        }
        else if (script.aiServiceShot == true)
        {
            script.aisFirstShot = true;
            script.playersFirstShot = false;
            Debug.Log("aifirstshotsettrue");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            ballTeleport();
            script.score = true;
            Debug.Log("score");
        }
    }
}
