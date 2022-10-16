using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    private float leftBoundary = -11.0f;

    // Update is called once per frame
    void Update()
    {
        //Scroll the gameObjects to the left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime, Space.World);

        //Delete any objects that pass the left bound (go off screen) and are not the background
        if (transform.position.x < leftBoundary && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
