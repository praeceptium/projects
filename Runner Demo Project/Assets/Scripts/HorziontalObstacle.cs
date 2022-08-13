using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorziontalObstacle : MonoBehaviour
{
    [SerializeField] private Transform RightEnd;
    [SerializeField] private Transform LeftEnd;

    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = RightEnd;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            if (target == LeftEnd)
            {
                target = RightEnd;
            }
            else
            {
                target = LeftEnd;
            }

        }
    }
}
