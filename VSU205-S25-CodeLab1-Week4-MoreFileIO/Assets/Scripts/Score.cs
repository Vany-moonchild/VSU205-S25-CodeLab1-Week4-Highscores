using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Score : MonoBehaviour
{
    [SerializeField]
    private List<int> highScores;

    private const string fileName = "highScores.txt";
    private string filePath = "";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<GameManager>();
        TMP_InputField scoreText = this.GetComponent<TMP_InputField>();
        
        
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
