using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject lifeOnePrefab;
    public GameObject lifeTwoPrefab;
    public GameObject lifeThreePrefab;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Lives == 3)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(true);
            lifeThreePrefab.SetActive(true);
        }

        if (GameManager.Instance.Lives == 2)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(true);
            lifeThreePrefab.SetActive(false);
        }

        if (GameManager.Instance.Lives == 1)
        {
            lifeOnePrefab.SetActive(true);
            lifeTwoPrefab.SetActive(false);
            lifeThreePrefab.SetActive(false);
        }

        if (GameManager.Instance.Lives == 0)
        {
            lifeOnePrefab.SetActive(false);
            lifeTwoPrefab.SetActive(false);
            lifeThreePrefab.SetActive(false);
        }
    }
}
