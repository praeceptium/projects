using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    float HighestScore = 0;
    public TextMeshProUGUI Hscore = new TextMeshProUGUI();
    // Start is called before the first frame update
    public void buttonClick()
    {
        Debug.Log("buttonclick");
        SceneManager.LoadScene("Game");
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void GetScore()
    {
        HighestScore = PlayerPrefs.GetFloat("score");
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void Start()
    {
        GetScore();
    }
    void Update()
    {
        Hscore.SetText("Highest Score is: " + HighestScore.ToString());
    }
}
