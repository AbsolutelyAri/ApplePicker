/*
*   Created by: Ben Krieger
*   Date Created: 2/7/2022
*   
*   Last Edited:
*   Last Edited By:
*   
*   Description: Main controller for the game.
*   
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketScript : MonoBehaviour
{
    //Holds a reference to the score text so it can be edited
    [Header("Set Dynamically")]
    public Text scoreText;

    private void Start()
    {
        GameObject scoreObject = GameObject.Find("ScoreCounter");
        scoreText = scoreObject.GetComponent<Text>();
        scoreText.text = "0";
    }

    void Update()
    {
        // Get mouse position
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // check if what hit the basket is the apple 
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // add 100 to the score when the apple is destroyed
            int score = int.Parse(scoreText.text);
            score += 100;
            scoreText.text = score.ToString();

            if(score > HighScoreScript.highScore)
            {
                HighScoreScript.highScore = score;
            }
        }
    }
}