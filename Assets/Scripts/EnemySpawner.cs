using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyNumber = 2;
    public GameObject enemyPrefab;
    public List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        BuildEnemyList();
    }

    // Update is called once per frame
    void BuildEnemyList()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
    }
}
