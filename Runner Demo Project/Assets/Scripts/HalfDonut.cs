using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    [SerializeField] private Transform RightEnd;
    [SerializeField] private Transform LeftEnd;

    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    bool firstWait=true;
    [SerializeField] private int firstWaitForSeconds;
    bool stopped;
    // Start is called before the first frame update
    void Start()
    {
        target = RightEnd;
    }
    IEnumerator WaitForSeconds(int sec)
    {
        stopped = true;
        yield return new WaitForSeconds(sec);
        stopped = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (firstWait == true)
        {
            StartCoroutine(WaitForSeconds(firstWaitForSeconds));
            firstWait = false;
        }
        else
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                if (target == LeftEnd && stopped == false)
                {
                    StartCoroutine(WaitForSeconds(3));
                    target = RightEnd;
                }
                else if (target == RightEnd && stopped == false)
                {
                    StartCoroutine(WaitForSeconds(2));
                    target = LeftEnd;
                }

            }
        }
        
    }
}
