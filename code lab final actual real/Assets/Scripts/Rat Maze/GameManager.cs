using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI titleUI;

    public LocationScriptableObject currentLocation;

    public LocationScriptableObject maze1;
    public LocationScriptableObject maze2;
    public LocationScriptableObject maze3;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;
    
    // Start is called before the first frame update
    void Start()
    {
        //hookup with scriptable object code
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
    }
    
    public void MoveDir(string dirChar)
    {
        switch (dirChar)
        {
            case "N":
                currentLocation = currentLocation.north;
                break;
            
            case "S":
                currentLocation = currentLocation.south;
                break;
            
            case "E":
                currentLocation = currentLocation.east;
                break;
            
            case "W":
                currentLocation = currentLocation.west;
                break;
            default:
                //Debug.Log("ya broked it");
                break;
            
        }
        
        currentLocation.UpdateCurrentLocation(this);
    }

    private void Update()
    {
        if (currentLocation == maze1)
        {
            //switch scene to ascii map and load level 1
            SupremeGameManager.instance.maze1 = true;
            SceneManager.LoadScene("ASCII Maze");
        }

        if (currentLocation == maze2)
        {
            //switch scene to ascii map and load level 2
            SupremeGameManager.instance.maze2 = true;
            SceneManager.LoadScene("ASCII Maze");
        }

        if (currentLocation == maze3)
        {
            //switch scene to ascii map and load level 3
            SupremeGameManager.instance.maze3 = true;
            SceneManager.LoadScene("ASCII Maze");
        }
    }
}
