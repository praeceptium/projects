using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    //Rigidbody rigid;
    // this must be public because of AI try to reach this value.
    public bool rotateRight = false;

    // Update is called once per frame
    void Update()
    {
        if (rotateRight == true)
        {
            transform.Rotate(Vector3.back * 10 * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(Vector3.forward * 10 * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //rigid = other.gameObject.GetComponent<Rigidbody>();
        //rigid.AddForce(Vector3.up * Time.deltaTime * 200f, ForceMode.Impulse);
        if(other.tag == "player")
        {
            if (rotateRight == true)
            {
                other.attachedRigidbody.AddForce(Vector3.right * Time.deltaTime * 50f, ForceMode.VelocityChange);
            }
            else
            {
                other.attachedRigidbody.AddForce(Vector3.left * Time.deltaTime * 50f, ForceMode.VelocityChange);
            }
        }
        
    }
}
