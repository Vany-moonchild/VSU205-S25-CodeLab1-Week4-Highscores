using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;

    public int gameTime = 10;

    public int currentTime = 0;

    public const string TimerTick = "UpdateTimer";
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //setting TimerString string function to the timerDisplay to show gameTime on screen
        timerDisplay.text = TimerString(gameTime);

        //Invoke(TimerTick, 1);
        InvokeRepeating(TimerTick, 1, 1);
    }

    public void UpdateTimer()
    {
        currentTime++;

        if (currentTime == gameTime)
        {
            GameManager.instance.UpdateHighScores();
            timerDisplay.text = "GAME OVA";
            CancelInvoke(TimerTick);
        }
        else
        {
            timerDisplay.text = TimerString(gameTime - currentTime);
            //Invoke(TimerTick,1 );
        }
    }

    //function to stop us from having to write the string several times
    string TimerString(int timeInt)
    {
        string result = "";
        
        result = "Time: " + timeInt + " Score: " + GameManager.instance.Score;

        return result;
    }

}
