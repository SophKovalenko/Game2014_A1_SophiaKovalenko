//////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 16th, 2022
//  Last modified: October 16th, 2022
//////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveToLeft : MonoBehaviour
{
    private float scrollSpeed = 3.5f;
    private float leftBoundary = -11.0f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.HasPlayerSpedUp == true)
        {
            scrollSpeed = 6.0f;
        }

        if (GameManager.Instance.HasPlayerSpedUp == false)
        {
            scrollSpeed = 3.5f;
        }

        //Scroll the gameObjects to the left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime, Space.World);

        //Delete any objects that pass the left bound (go off screen) and are not the background
        if (transform.position.x < leftBoundary && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
