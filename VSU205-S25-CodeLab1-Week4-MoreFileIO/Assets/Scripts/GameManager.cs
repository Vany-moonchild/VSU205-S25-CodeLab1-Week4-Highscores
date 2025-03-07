using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Timer timer;
    
    private int score = 0;
    
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

    [SerializeField]
    private List<int> highScores;
    
    private const string fileName = "highScores.txt";
    private string filePath = "";
    
    
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

    //don't get components in Awake - do that in Start as they will be available to take
    void Start()
    {
        timer = GetComponent<Timer>();
        
        filePath = Application.dataPath + "/Data/" + fileName;

        if (File.Exists(filePath))
        {
            //TODO Get values from file  
            string fileContents = File.ReadAllText(filePath);
            string[] lines = fileContents.Split('\n');

            foreach (var line in lines)
            {
                //turning the string into integer characters
                highScores.Add(int.Parse(line));
            }
        }
        else //if there is no file 
        {
            //set the highScore result values
            for (int i = 0; i < 10; i++)
            {
                highScores.Add(10 - i);
            }
        }


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighScores()
    {
        //count is the .Length version for a list - you can modify lists unlike an array
        for (int i = 0; i < highScores.Count; i++)
        {
            int currentHS = highScores[i];

            //if its a tie with old highscore replace it with new player
            if (score >= currentHS)
            {
                highScores.Insert(i, score);
                break;
            }
        }

        if (highScores.Count > 10)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }
        
        string fileContents = "";
        
        foreach (var scoreData in highScores)
        {
            fileContents += scoreData + "\n"; //\n to send the text to a new line
        }
        
        
        File.WriteAllText(filePath, fileContents);
    }
}
