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
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Called by apples when they're destroyed, clear the screen of apples and get rid of a basket. Restart the game if there are 0 baskets remaining
    public void AppleDestroyed()
    {
        // clear all apples off screen
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }
        // remove a basket
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //check if basketCount is 0, trigger game over if its true
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("ApplePickerScene");
        }
    }
}