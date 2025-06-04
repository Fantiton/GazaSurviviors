using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Israel, Palestine };
public class EnemySpawner : MonoBehaviour
{
    List<Transform> spawnPoints;
    public GameObject modelJew;
    public GameObject modelArab;
    public GameObject enemy;
    public Side side;
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

        if(side == Side.Israel)
        {
            Debug.Log(side);
            GameObject newEnemy = Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
            Instantiate(modelArab, newEnemy.transform);
            enemy.GetComponent<EnemyController>().enemyHealth = 10;
        }
        if(side == Side.Palestine)
        {
            Debug.Log(side);
            GameObject newEnemy = Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
            Instantiate(modelJew, newEnemy.transform);
            enemy.GetComponent<EnemyController>().enemyHealth = 10;
        }
    }
}
