using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            GameManager.instance.gameOver = false;
        }
        else
        {
            GameManager.instance.gameOver = true;
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length > 21)
        {
            GameManager.instance.gameOver = true;
        }
    }

}
