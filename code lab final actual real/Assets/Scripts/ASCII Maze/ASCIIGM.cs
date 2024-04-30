using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ASCIIGm : MonoBehaviour
{
    int currentLevel;
    GameObject level;
    string FILE_PATH;
    
    public TextMeshProUGUI instructions;

    public static ASCIIGm instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";
        
        //different level is loaded depending on which exit you went out of
        if (SupremeGameManager.instance.maze1 == true)
        {
            currentLevel = 0;
        }

        if (SupremeGameManager.instance.maze2 == true)
        {
            currentLevel = 1;
        }

        if (SupremeGameManager.instance.maze3 == true)
        {
            currentLevel = 2;
        }
        
        LoadLevel();
        
    }

    void Update()
    {
        instructions.text = "Click and drag yourself through the maze to the goal.";
    }

    void LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level Objects");
        
        //get lines from file
         string[] lines = File.ReadAllLines(
            FILE_PATH.Replace("Num", currentLevel + ""));

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            //get one line
            string line = lines[yLevelPos].ToUpper();
            
            //turn into char array
            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                //get first chara
                char c = characters[xLevelPos];

                GameObject newObject = null;

                switch (c)
                {
                    case 'W': //wall
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;
                    case 'H': //hazard
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Hazard"));
                        break;
                    case 'P': //player
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        break;
                    case 'G': //goal
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Goal"));
                        break;
                    default:
                        break;
                }

                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;
                    
                    //position based on location in file
                    newObject.transform.position = new Vector2(xLevelPos, -yLevelPos);
                }
            }
        }
    }
}
