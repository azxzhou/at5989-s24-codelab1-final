using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannon : MonoBehaviour
{
    public int speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up, Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.down, Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }
}
