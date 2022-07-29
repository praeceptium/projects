using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableCollider : MonoBehaviour
{
    [SerializeField] bool isPlayerSide;
    [SerializeField] bool isAISide;
    public GameHandler script;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (isPlayerSide == true)
        {
            if(other.tag=="ball")
                script.playerBounce += 1;
        }if(isAISide == true)
        {
            if (other.tag == "ball")
                script.aiBounce += 1;
        }

    }
}
