using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameCheckGM : MonoBehaviour
{
    public TMP_InputField input;
    public TextAsset textFileWithNames;
    public TextMeshProUGUI display;

    private List<string> namesList;

    bool readInstructions = false;

    bool fakeName = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //instantiate list
        namesList = new List<string>();
        
        //split file into lines
        var namesFromFile = textFileWithNames.text.Split('\n');
        
        //for loop goes through all lines
        for (int i = 0; i < namesFromFile.Length; i++)
        {
            //add each line to namesList
            namesList.Add(namesFromFile[i].ToUpper().Trim());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if nothing in text box, show instructions
        if (input.text == "")
        {
            display.text = "Please enter your name. Do not use your real name.";
        }
        //check if entered name is in list
        else
        {
            display.text = "You didn't use your real name. Good. Now press Tab.";

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SceneManager.LoadScene("Rat Maze");
            }
            

            if (namesList.Contains(input.text.ToUpper()))
            {
                display.text = "Really? You couldn't resist?";
            }
        }
    }
}
