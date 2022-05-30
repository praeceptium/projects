using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public float speed;
    public bool cameralock=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameralock == false && transform.position.x>= -10.79307 && transform.position.x<= 4.370989)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, 0, 0);
            if (transform.position.x <= -10.79307)
            {
                transform.position = new Vector3(-10.79306f, 4.57f, -2.625f);
            }
            if (transform.position.x >= 4.370989)
            {
                transform.position = new Vector3(4.370988f, 4.57f, -2.625f);
            }
        }
        
    }
}
