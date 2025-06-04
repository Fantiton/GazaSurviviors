using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if(Instance == null) Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame(Side s)
    {
        SceneManager.LoadScene("SampleScene");
        StartCoroutine(InitializeGame(s));
    }

    private IEnumerator InitializeGame(Side s)
    {
        yield return new WaitForSeconds(0.01f);

        GameObject enemySpawnerObject = GameObject.Find("EnemySpawner");
        if (enemySpawnerObject != null)
        {
            EnemySpawner enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();
            enemySpawner.side = s;
            Debug.Log("EnemySpawner side set to: " + enemySpawner.side);
        }
        GameObject levelManagerObject = GameObject.Find("LevelManager");
        if (levelManagerObject != null)
        {
            LevelManager levelManager = levelManagerObject.GetComponent<LevelManager>();
            levelManager.SetSide(s);
            Debug.Log("LevelManager side set to: " + levelManager.side);
        }
    }
}
