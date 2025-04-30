using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Transform> spawnPoints;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Transform sp = transform.Find("SpawnPositions");
        spawnPoints = new List<Transform>();
        foreach (Transform child in sp) 
        {
            spawnPoints.Add(child);
        }

        InvokeRepeating("Spawn", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        int index = Random.Range(0, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().enemyHealth = 10;
    }
}
