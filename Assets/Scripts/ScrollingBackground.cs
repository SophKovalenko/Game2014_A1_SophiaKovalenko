//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 16th, 2022
//  Last modified: October 16th, 2022
//  - this script scrolls the background to the left seamlessly so it looks like the player is moving forward
//////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Vector3 startingPosition;
    private float backgroundWidth;

    // Start is called before the first frame update
    void Start()
    {
        //Find and set the starting position of Background game object
        startingPosition = transform.position;

        //Used to find when the background will be 1/5th past the game screen
        backgroundWidth = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        //If background passes half the screen, repeat it
        if (transform.position.x < startingPosition.x - backgroundWidth)
        {
            transform.position = startingPosition;
        }
    }
}
