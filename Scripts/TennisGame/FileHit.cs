using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileHit : MonoBehaviour
{
    public GameHandler script;

    private void OnTriggerEnter(Collider other)
    {
        script.fileAddScore();

    }
}
