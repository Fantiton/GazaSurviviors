using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject gameOverCanvas;
    public GameObject pauseMenuPanel;
    int points;
    int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 10;
        points = 0;
        gameOverCanvas.SetActive(false);
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

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);    
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
