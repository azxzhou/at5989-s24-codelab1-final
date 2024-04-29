using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    public GameObject cannonball;

    public GameObject ballHolder;

    int shootForce = 50;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pew pew
        Shoot();
        
    }

    void Shoot()
    {
        //if mouse button is clicked
        if (GameManager.instance.gameOver == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //instantiate clone of prefab
                GameObject newDrop = Instantiate(cannonball, ballHolder.transform);
            
                //set spawn location
                newDrop.transform.position =
                    new Vector3(
                        transform.position.x,
                        transform.position.y + 1,
                        transform.position.z + 1);

                //tell game to access rigidbody on cloned object and apply force to it
                Rigidbody cannonballRb = newDrop.GetComponent<Rigidbody>();
                cannonballRb.AddForce(shootForce * transform.up, ForceMode.Impulse);
            
                //add 1 to cannonballs used counter
                GameManager.instance.score++;

            }
        }
    }
    
}
