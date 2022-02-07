/*
*   Created by: Ben Krieger
*   Date Created: 1/31/2022
*   
*   Last Edited: 2/7/2022
*   Last Edited By:
*   
*   Description: Destroys the apple once its off screen 
*   
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < bottomY)
        {
            ApplePicker aScript = Camera.main.GetComponent<ApplePicker>();
            aScript.AppleDestroyed();
            
            Destroy(this.gameObject);
        }
    }
}
