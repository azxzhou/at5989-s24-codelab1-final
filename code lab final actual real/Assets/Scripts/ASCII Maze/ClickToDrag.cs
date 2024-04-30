using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO;
using UnityEngine;
using Input = UnityEngine.Input;


public class ClickToDrag : MonoBehaviour
{
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector2 GetMouseWorldPosition()
    {
        //grab mouse position
        Vector2 result = Input.mousePosition;
        
        //where is the spot in the world?
        result = Camera.main.ScreenToWorldPoint(result);

        return result;
    }
}
