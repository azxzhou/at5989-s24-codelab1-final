using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    int speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = Vector2.up * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = Vector2.down * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = Vector2.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = Vector2.right * speed * Time.deltaTime;
        }
    }
}
