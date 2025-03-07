using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] GameObject highScoreUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ShowPanel()
    {
        highScoreUI.SetActive(true);
    }

    public void HidePanel()
    {
        highScoreUI.SetActive(false);
    }
 
}
