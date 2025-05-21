using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Side {Israel, Palestine};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Side side;

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
        side = s;
        SceneManager.LoadScene("SampleScene");
    }
}
