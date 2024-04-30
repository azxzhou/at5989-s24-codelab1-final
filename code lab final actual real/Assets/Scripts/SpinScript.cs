using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    
  
    void Update()
    {
        //SPEEN
        transform.Rotate(new Vector3(30, 30, 30) * Time.deltaTime * 5);
    }
}
 