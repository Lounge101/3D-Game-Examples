using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    public Transform objectToFollow;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position + objectToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position + _offset;
    }
}
