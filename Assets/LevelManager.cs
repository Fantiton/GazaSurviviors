using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public Side side;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameOverCanvas;
    public GameObject pauseMenuPanel;
    public GameObject player;
    public GameObject modelJew;
    public GameObject modelArab;
    int points;
    int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 10;
        points = 0;
        gameOverCanvas.SetActive(false);    
    }

    public void SetSide(Side s)
    {
        side = s;
        Debug.Log("LevelManager side set to: " + side);

        if (side == Side.Israel)
        {
            Instantiate(modelJew, player.transform);
        }

        if (side == Side.Palestine)
        {
            Instantiate(modelArab, player.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Wynik: " + points.ToString();
        healthText.text = "HP: " + playerHealth.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuPanel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    public void ReducePlayerHealth(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
            gameOverCanvas.SetActive(true);
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);    
    }

    void MainMenu()
    {
        Time.timeScale = 1;
    }

    void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
