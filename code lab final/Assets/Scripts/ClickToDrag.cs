using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ClickToDrag : MonoBehaviour
{
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 result = Input.mousePosition;
        result.z = Camera.main.WorldToScreenPoint(transform.position).z;
        result = Camera.main.ScreenToWorldPoint(result);
        return result;
    }
}
