using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver = false;

    public TextMeshProUGUI gameOverText;
    
    public TextMeshProUGUI ballCountText;

    public TextMeshProUGUI highScoreText;

    public TextMeshProUGUI optionsText;
    
    //high score tracking
    public int score;

    const string FILE_DIR = "/DATA/";
    const string DATA_FILE = "highScores.txt";

    string FILE_FULL_PATH;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    string highScoresString = "";

    List<int> highScores;

    public List<int> HighScores
    {
        get
        {
            if (highScores == null && File.Exists(FILE_FULL_PATH))
            {
                highScores = new List<int>();

                highScoresString = File.ReadAllText(FILE_FULL_PATH);

                highScoresString = highScoresString.Trim();

                string[] highScoreArray = highScoresString.Split("\n");
               
                for (int i = 0; i < highScoreArray.Length; i++)
                {
                    int currentScore = Int32.Parse(highScoreArray[i]);
                    highScores.Add(currentScore);
                }
            }
            else if (highScores == null)
            {
                highScores = new List<int>();
                highScores.Add(8);
                highScores.Add(7);
                highScores.Add(6);
            }

            return highScores;
        }
    }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        FILE_FULL_PATH = Application.dataPath + FILE_DIR + DATA_FILE;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver == true)
        {
            SetHighScore();

            gameOverText.text = "game over!";

            ballCountText.text = "you used " + score + " cannonballs";

            highScoreText.text = "the current high score is " + highScoresString + " cannonballs";

            optionsText.text = "press P to restart, or press I to see a list of high scores";

        }
        else
        {
            gameOverText.text = "";

            ballCountText.text = "";

            highScoreText.text = "";

            optionsText.text = "";
        }
        
    }

    bool IsHighScore(int score)
    {
        for (int i = 0; i < HighScores.Count; i++)
        {
            if (highScores[i] > score)
            {
                return true;
            }
            
        }

        return false;
    }

    void SetHighScore()
    {
        if (IsHighScore(score))
        {
            int highScoreSlot = -1;

            for (int i = 0; i < HighScores.Count; i++)
            {
                if (score < highScores[i])
                {
                    highScoreSlot = i;
                    break;
                }
            }
            
            highScores.Insert(highScoreSlot, score);

            highScores = highScores.GetRange(0, 1);
            
            string scoreBoardText = "";

            foreach (var highScore in highScores)
            {
                scoreBoardText += highScore + "\n";
            }

            highScoresString = scoreBoardText;
            
            File.WriteAllText(FILE_FULL_PATH,highScoresString);
        }
    }
}
