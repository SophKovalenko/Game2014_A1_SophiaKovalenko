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
