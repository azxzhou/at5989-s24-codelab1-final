using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{

    public Rigidbody cannonball;
    int cannonForce = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        cannonball = GetComponent<Rigidbody>();
        InvokeRepeating("Shoot", 2f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody clone;
            clone = Instantiate(cannonball, transform.position, transform.rotation);

            cannonball.AddForce(transform.forward * cannonForce);
        }
        
    }
    
    void Shoot()
    {
        Rigidbody newSphere = Instantiate<Rigidbody>(cannonball);
    }
}
