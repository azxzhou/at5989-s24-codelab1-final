using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveCannon : MonoBehaviour
{
    float rotationSpeed = 45;
    float moveSpeed = 10;


    // Update is called once per frame
    void Update()
    {
        
        //rotate cannon up and down
        if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles += Vector3.right * rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles += Vector3.left * rotationSpeed * Time.deltaTime;
        }
        
        //move cannon left and right
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        
    }
}
