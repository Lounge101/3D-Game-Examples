using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype1Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float RotationSpeed = 45f;

    private float _horizontalInput;
    private float _verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Speed * _verticalInput * Time.deltaTime);

        // Turn the vehicle
        transform.Rotate(Vector3.up, RotationSpeed * _horizontalInput * Time.deltaTime);
    }
}
