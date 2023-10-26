using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public bool completed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        Vector3 newPosition = new Vector3(transform.position.x, -6, transform.position.z);
        if (completed)
        {
            transform.rotation = Quaternion.Lerp(startRotation, newRotation, 0.01f);
            transform.position = Vector3.Lerp(startPosition, newPosition, 0.001f);

        }
    }
}
