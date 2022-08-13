using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTurn : MonoBehaviour
{
    private Vector3 playerMovementInput;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform rotationTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (playerMovementInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovementInput, Vector3.up);
            rotationTransform.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
