/*
*   Created by: Ben Krieger
*   Date Created: 2/7/2022
*   
*   Last Edited: 
*   Last Edited By:
*   
*   Description: Controls the high-score script
*   
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    [Header("THERE CAN BE ONLY ONE!")]
    static public int highScore = 1000;

    // Happens before start
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", highScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // set the High Score text to be highScore
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + highScore;

        if (highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
