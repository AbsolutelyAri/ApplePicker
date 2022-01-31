/*
*   Created by: Ben Krieger
*   Date Created: 1/31/2022
*   
*   Last Edited
*   Last Edited By:
*   
*   Description: Controls the tree movement and apple spawning. 
*   
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeScript : MonoBehaviour
{
    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirection = .1f;

    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixed Update is called on a regular interval 50 times per second
    private void FixedUpdate()
    {
        //move the tree every frame
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //turn the tree around

        /* this is the default code but I tried doing it my own way
         * if(pos.x <= -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if(pox.x >= leftAndRightEdge) {
            speed = -speed;
        }*/
        if (pos.x <= -leftAndRightEdge || pos.x >= leftAndRightEdge)
        {
            speed = -speed;
        }
        else if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position; //move apple to the tree
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
